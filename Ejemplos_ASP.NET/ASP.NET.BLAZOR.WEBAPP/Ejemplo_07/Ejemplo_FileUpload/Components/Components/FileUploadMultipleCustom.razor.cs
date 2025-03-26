using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Ejemplo_FileUpload.Components.Components;

public partial class FileUploadMultipleCustom
{
    [Parameter]
    public List<FileWrapper> selectedFiles { get; set; } = new();

    private int inputFileKey = 0;

    private string message = "";

    public class FileWrapper
    {
        public IBrowserFile File { get; set; }
        public string FullPath { get; set; }
        public string Name => File.Name;
        public byte[] Content { get; set; }
    }

    async private Task HandleFilesSelection(InputFileChangeEventArgs e)
    {
        message = "";
        try
        {
            foreach (var file in e.GetMultipleFiles())
            {
                using var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);

                selectedFiles.Add(new FileWrapper
                {
                    File = file,
                    Content = ms.ToArray() // Guarda el contenido en memoria
                });
            }
        }
        catch (Exception ex)
        {
            message = "Error uploading files";
        }
    }

    private void RemoveFile(string fileName)
    {
        message = "";
        selectedFiles.RemoveAll(f => f.Name == fileName);
        inputFileKey++;
        StateHasChanged();
    }

    public async Task UploadFiles()
    {
        message = "";
        if (selectedFiles.Count == 0)
        {
            message = "No se han seleccionado archivos.";
            return;
        }
        try
        {
            var uploadPath = Path.Combine(Env.WebRootPath, "upload");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var fileWrapper in selectedFiles)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{fileWrapper.Name}";
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                await using var stream = new FileStream(filePath, FileMode.Create);

                using var ms = new MemoryStream(fileWrapper.Content);

                await ms.CopyToAsync(stream);
            }

            message = $"Se han subido {selectedFiles.Count} archivos correctamente.";
            selectedFiles.Clear();
            inputFileKey++;
        }
        catch (Exception ex)
        {
            message = $"Error: {ex.Message}";
            Logger.LogError(ex, "Error uploading files");
        }
    }
}
