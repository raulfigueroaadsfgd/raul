using TesseractCSharp;

Console.WriteLine("Tesseract OCR 5.3.4 - Sample Application");
Console.WriteLine("==========================================\n");

// Check if tessdata directory exists
string tessdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");
if (!Directory.Exists(tessdataPath))
{
    Console.WriteLine($"ERROR: tessdata directory not found at: {tessdataPath}");
    Console.WriteLine("Please create a 'tessdata' directory and download language data files from:");
    Console.WriteLine("https://github.com/tesseract-ocr/tessdata_fast");
    Console.WriteLine("\nFor example, download 'eng.traineddata' for English OCR.");
    return;
}

// Check if image file is provided as argument
if (args.Length == 0)
{
    Console.WriteLine("Usage: ConsoleApp1 <image_path>");
    Console.WriteLine("\nExample: ConsoleApp1 sample.png");
    Console.WriteLine("\nThis application will perform OCR on the provided image.");
    return;
}

string imagePath = args[0];
if (!File.Exists(imagePath))
{
    Console.WriteLine($"ERROR: Image file not found: {imagePath}");
    return;
}

try
{
    Console.WriteLine($"Processing image: {imagePath}");
    Console.WriteLine($"Using tessdata from: {tessdataPath}\n");

    using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
    using (var img = Pix.LoadFromFile(imagePath))
    {
        using (var page = engine.Process(img))
        {
            string text = page.GetText() ?? string.Empty;
            float confidence = page.GetMeanConfidence();

            Console.WriteLine("OCR Results:");
            Console.WriteLine("============");
            Console.WriteLine($"Confidence: {confidence:P2}");
            Console.WriteLine($"\nExtracted Text:\n{text}");
        }
    }

    Console.WriteLine("\nOCR processing completed successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
    Console.WriteLine($"\nStack trace: {ex.StackTrace}");
}
