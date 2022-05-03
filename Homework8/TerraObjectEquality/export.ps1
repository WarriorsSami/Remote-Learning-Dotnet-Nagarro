# ==============================================================================
# This script creates a zip archive containing the code from this repo.
# It is useful to generate the package that must be provided to the students.
# 
# !!! Make sure you are on the correct branch.
# The master branch contains the skeleton project we want to give to the students.
#
# Files excluded from the package:
# - bin/
# - obj/
# - .gitignore
# - .gitattributes
# - .vs
# ==============================================================================

# ------------------------------------------------------------------------------
# Parameters
# ------------------------------------------------------------------------------

$exportName = "Terra - Object Equality"

$sourcesPath = ".\sources"
$requirementsPath = ".\requirements"

$exportPath = ".\exports"
$exportZipFileName = "$exportName.zip"





# ------------------------------------------------------------------------------
# Clean old export
# ------------------------------------------------------------------------------

If (Test-Path $exportPath)
{
	Remove-Item $exportPath -Recurse -Force
}


# ------------------------------------------------------------------------------
# Copy all sources
# ------------------------------------------------------------------------------

New-Item -Path "$exportPath\$exportName" -ItemType Directory
Copy-Item -Path "$sourcesPath\*" -Recurse -Destination "$exportPath\$exportName" -Force


# ------------------------------------------------------------------------------
# Remove unnecessary files and directories
# ------------------------------------------------------------------------------

Get-ChildItem -Path "$exportPath\$exportName" -Include ".vs" -Recurse -Force | Remove-Item -Force -Recurse

Get-ChildItem -Path "$exportPath\$exportName" -Include ".gitattributes" -Recurse -Force | Remove-Item -Force -Recurse
Get-ChildItem -Path "$exportPath\$exportName" -Include ".gitignore" -Recurse -Force | Remove-Item -Force -Recurse

Get-ChildItem -Path "$exportPath\$exportName" -Include "bin" -Recurse -Force | Remove-Item -Force -Recurse
Get-ChildItem -Path "$exportPath\$exportName" -Include "obj" -Recurse -Force | Remove-Item -Force -Recurse
Get-ChildItem -Path "$exportPath\$exportName" -Include "TestResults" -Recurse -Force | Remove-Item -Force -Recurse

Get-ChildItem -Path "$exportPath\$exportName" -Include "readme.md" -Recurse -Force | Remove-Item -Force -Recurse


# ------------------------------------------------------------------------------
# Copy the requirements
# ------------------------------------------------------------------------------

New-Item -Path "$exportPath\$exportName\Requirements" -ItemType Directory
Copy-Item -Path "$requirementsPath\*" -Recurse -Destination "$exportPath\$exportName\Requirements" -Force


# ------------------------------------------------------------------------------
# Pack the export (zip)
# ------------------------------------------------------------------------------

Compress-Archive -Path "$exportPath\$exportName" -DestinationPath "$exportPath\$exportZipFileName"


# ------------------------------------------------------------------------------
# Remove temporary files
# ------------------------------------------------------------------------------

Remove-Item "$exportPath\$exportName" -Recurse -Force


# ------------------------------------------------------------------------------
# Display git branches
# ------------------------------------------------------------------------------

echo .
echo "================================================================================"
echo "Finished exporting from branch:"
git branch
echo "================================================================================"