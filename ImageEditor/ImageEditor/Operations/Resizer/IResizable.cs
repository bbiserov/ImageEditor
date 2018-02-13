namespace ImageEditor.Operations.Resizer
{
    interface IResizable
    {
        void Resize(string sourcePath, string destinationPath, int width, int height);
    }
}
