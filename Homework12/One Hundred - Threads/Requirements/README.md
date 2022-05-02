# One Hundred

## Overview

We have an application that increments the same variable (a number) from 100 different threads. Each thread must increment it 1 million times.

The expected result should be 100 million, but the actual value is different. Always a smaller number. It appears to be random. We do not know why this happens.

See the `UnsafeJob` class for the implementation that needs to be improved.

## Requirements

1) Find a way to fix the incrementation of the value.

2) Find as many solution as possible. How many synchronization mechanisms can you find that can fix the problem?

> **Notes:**
>
> - The 100 threads cannot be removed.
> - The value must still be allowed to be incremented concurrently from all the threads, but it must be done in a safe way. We cannot afford to block all threads until one of them finishes the whole job. We need each thread to be able to do a few increments then allow some other thread to do a few increments and so on.

## Suggestions

Implement each solution as a new class that implements the `IJob` interface and add it into the jobs collection from `JobsWorld` class.