# raul

Tesseract OCR 5.3.4 Console Application

## Overview

This repository contains a C# console application that demonstrates Tesseract OCR 5.3.4 functionality. Tesseract is an open-source Optical Character Recognition (OCR) engine that can extract text from images.

## Features

- Uses Tesseract OCR 5.3.4 via TesseractCSharp NuGet package
- Cross-platform support (Windows, Linux, macOS)
- Supports 100+ languages
- Simple command-line interface

## Prerequisites

- .NET 8.0 SDK or later
- Language data files (tessdata) - see setup instructions below

## Quick Start

1. **Clone the repository**
   ```bash
   git clone https://github.com/raulfigueroaadsfgd/raul.git
   cd raul
   ```

2. **Build the project**
   ```bash
   dotnet build ConsoleApp1.sln
   ```

3. **Set up tessdata** (required for OCR)
   
   Download English language data:
   ```bash
   mkdir -p ConsoleApp1/bin/Debug/net8.0/tessdata
   cd ConsoleApp1/bin/Debug/net8.0/tessdata
   curl -LO https://github.com/tesseract-ocr/tessdata_fast/raw/main/eng.traineddata
   cd ../../../..
   ```

   For detailed setup instructions and other languages, see [ConsoleApp1/TESSDATA_SETUP.md](ConsoleApp1/TESSDATA_SETUP.md)

4. **Run the application**
   
   **Linux:**
   ```bash
   # Test with the included sample image
   LD_LIBRARY_PATH=./ConsoleApp1/bin/Debug/net8.0/tesseractLib/linux_x64:$LD_LIBRARY_PATH dotnet run --project ConsoleApp1 ConsoleApp1/sample.png
   ```
   
   **Windows/macOS:**
   ```bash
   # Test with the included sample image
   dotnet run --project ConsoleApp1 ConsoleApp1/sample.png
   ```

## Usage

### Linux Note
On Linux, you may need to set the LD_LIBRARY_PATH to include the native libraries:

```bash
# Set LD_LIBRARY_PATH (required on Linux)
export LD_LIBRARY_PATH=/path/to/ConsoleApp1/bin/Debug/net8.0/tesseractLib/linux_x64:$LD_LIBRARY_PATH

# Process an image
dotnet run --project ConsoleApp1 sample.png

# Or in one command:
LD_LIBRARY_PATH=./ConsoleApp1/bin/Debug/net8.0/tesseractLib/linux_x64:$LD_LIBRARY_PATH dotnet run --project ConsoleApp1 sample.png
```

### General Usage

```bash
# Process an image
dotnet run --project ConsoleApp1 <path-to-image>

# Or after building:
cd ConsoleApp1/bin/Debug/net8.0
./ConsoleApp1 sample.png
```

## Project Structure

```
raul/
├── ConsoleApp1/              # Main OCR console application
│   ├── Program.cs            # OCR implementation
│   ├── ConsoleApp1.csproj    # Project file with Tesseract 5.3.4
│   └── TESSDATA_SETUP.md     # Language data setup guide
├── ConsoleApp1.sln           # Visual Studio solution
├── README.md                 # This file
└── .gitignore               # Git ignore rules
```

## Dependencies

- **TesseractCSharp 1.0.5** - .NET wrapper for Tesseract OCR 5.3.4
- **.NET 8.0** - Target framework

## Language Support

Tesseract supports over 100 languages. Download additional language files from:
- Fast models: https://github.com/tesseract-ocr/tessdata_fast
- Best quality: https://github.com/tesseract-ocr/tessdata_best

## License

This project uses Tesseract OCR which is licensed under the Apache License 2.0.

## Resources

- [Tesseract OCR Official Site](https://github.com/tesseract-ocr/tesseract)
- [TesseractCSharp NuGet Package](https://www.nuget.org/packages/TesseractCSharp)
- [Language Data Files](https://github.com/tesseract-ocr/tessdata)
