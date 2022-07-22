function Publish-Directory
{
    param (
        [string] $Activity,
        [string] $FileFilter,
        [ScriptBlock] $Func
    )

    $x = 0
    $fileList = Get-Item $FileFilter
    $fileList | ForEach-Object {
        Write-Progress -Activity $Activity -Status "Source File: $_" -PercentComplete ($x / $fileList.Count * 100);
        $x++;
        &$Func -file $_ 
    }
}

Push-Location .\Serialize-csharp

# Ideally, this should use avrogen.exe, too, but that doesn't seem to work with Protocol files
Write-Host 'Phase1: Auto generating Avro schemata from Avro IDL ...'
$func1 = { param($file) java -jar ..\AvroTools\avro-tools-1.8.1.jar idl2schemata $file .\Generated }
Publish-Directory -Activity "Generating Schemata" -FileFilter ..\*.avdl -Func $func1

Write-Host 'Phase2: Auto generating C# classes from Avro schemata'
$func2 = { param($file) avrogen.exe -s $file .\Generated } # Avro official method
# $func2 = { param($file) ..\AvroTools\Microsoft.Hadoop.Avro.Tools.exe CodeGen /I:"$_" /O:.\Generated >> results.txt } # Microsoft Hadoop method
# Get-Date > results.txt # Reset the results.txt file
Publish-Directory -Activity "Generating C# code files" -FileFilter .\Generated\*.avsc -Func $func2

Pop-Location