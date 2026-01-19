# Tesseract OCR 5.3.4 - README

This guide will help you download and set up the tessdata files required for OCR.

## Quick Setup

1. Create a `tessdata` directory in the build output folder (where ConsoleApp1.exe is located)
2. Download language data files from the official Tesseract repository
3. Place the `.traineddata` files in the `tessdata` directory

## Downloading Language Data

### Option 1: Fast Models (Recommended for most users)
Download from: https://github.com/tesseract-ocr/tessdata_fast

These models are smaller and faster but slightly less accurate.

### Option 2: Best Quality Models
Download from: https://github.com/tesseract-ocr/tessdata

These models provide the highest accuracy but are slower.

### Option 3: Best Quality + Best Coverage
Download from: https://github.com/tesseract-ocr/tessdata_best

These models have the best quality and coverage for all languages.

## Common Languages

- **English**: Download `eng.traineddata`
- **Spanish**: Download `spa.traineddata`
- **French**: Download `fra.traineddata`
- **German**: Download `deu.traineddata`
- **Chinese Simplified**: Download `chi_sim.traineddata`
- **Arabic**: Download `ara.traineddata`

## Directory Structure

After setup, your directory should look like:
```
ConsoleApp1/
├── bin/
│   └── Debug/
│       └── net8.0/
│           ├── ConsoleApp1.exe
│           └── tessdata/
│               ├── eng.traineddata
│               └── [other language files]
```

## Copying tessdata to Build Output

You can automate copying the tessdata folder to the build output by adding this to your `.csproj` file:

```xml
<ItemGroup>
  <None Include="tessdata\**\*">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

## Example Download Commands

### Using curl (Linux/Mac)
```bash
mkdir -p ConsoleApp1/bin/Debug/net8.0/tessdata
cd ConsoleApp1/bin/Debug/net8.0/tessdata
curl -LO https://github.com/tesseract-ocr/tessdata_fast/raw/main/eng.traineddata
```

### Using PowerShell (Windows)
```powershell
New-Item -ItemType Directory -Force -Path "ConsoleApp1\bin\Debug\net8.0\tessdata"
cd "ConsoleApp1\bin\Debug\net8.0\tessdata"
Invoke-WebRequest -Uri "https://github.com/tesseract-ocr/tessdata_fast/raw/main/eng.traineddata" -OutFile "eng.traineddata"
```

## Verifying Installation

After downloading the language files, you can verify by running:
```bash
dotnet run --project ConsoleApp1
```

This will show usage instructions if setup is correct.
