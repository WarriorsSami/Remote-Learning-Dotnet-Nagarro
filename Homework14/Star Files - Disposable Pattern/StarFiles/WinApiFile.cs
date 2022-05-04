using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using iQuest.StarFiles.WinApi;

namespace iQuest.StarFiles
{
    internal class WinApiFile : IDisposable
    {
        public const uint INVALID_SET_FILE_POINTER = 0xFFFFFFFF;

        private bool _disposed;

        private IntPtr _fileHandle;

        public string FileName { get; }

        public WinApiFile(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (fileName.Length == 0)
                throw new ArgumentNullException(nameof(fileName));

            FileName = fileName;
            Open();
        }

        private void Open()
        {
            const DesiredAccess access = DesiredAccess.GENERIC_READ | DesiredAccess.GENERIC_WRITE;

            _fileHandle = Kernel32.CreateFile(
                FileName,
                access,
                ShareMode.FILE_SHARE_READ,
                IntPtr.Zero,
                CreationDisposition.OPEN_ALWAYS,
                FlagsAndAttributes.NONE,
                IntPtr.Zero
            );

            if (_fileHandle.ToInt32() == -1)
                ThrowLastWin32Err();
        }

        private static void ThrowLastWin32Err()
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        public string ReadAll()
        {
            MoveFilePointer(0, MoveMethod.FILE_BEGIN);

            using var stream = new MemoryStream();
            var buffer = new byte[10240];

            uint actualReadCount = 0;

            while (true)
            {
                var success = Kernel32.ReadFile(
                    _fileHandle,
                    buffer,
                    (uint)buffer.Length,
                    ref actualReadCount,
                    IntPtr.Zero
                );

                if (!success)
                    ThrowLastWin32Err();

                if (actualReadCount == 0)
                    break;

                stream.Write(buffer, 0, (int)actualReadCount);
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public void Write(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            uint actualWriteCount = 0;

            var success = Kernel32.WriteFile(
                _fileHandle,
                bytes,
                (uint)bytes.Length,
                ref actualWriteCount,
                IntPtr.Zero
            );
            if (!success)
                ThrowLastWin32Err();
        }

        private void MoveFilePointer(int distance, MoveMethod moveMethod)
        {
            if (_fileHandle == IntPtr.Zero)
                return;

            var result = Kernel32.SetFilePointer(_fileHandle, distance, IntPtr.Zero, moveMethod);
            if (result == INVALID_SET_FILE_POINTER)
                ThrowLastWin32Err();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) { }

                Kernel32.CloseHandle(_fileHandle);
                _fileHandle = IntPtr.Zero;
                _disposed = true;
            }
        }
    }
}
