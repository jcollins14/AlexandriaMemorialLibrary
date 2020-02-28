namespace AlexandriaMemorialLibrary
{
    class Program
    {
        static void Main()
        {
            //Creates new librarycontroller, loads the saved library, and starts the application
            LibraryController alexandria = new LibraryController();
            alexandria.Load();
            alexandria.Run();
        }
    }
}
