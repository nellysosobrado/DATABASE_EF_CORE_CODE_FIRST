using EFCoreCodeFirstTogether_START.Controllers;
using EFCoreCodeFirstTogether_START.Data;

namespace EFCoreCodeFirstTogether_START
{
    public class Application
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly MainMenu _mainMenu;
        private readonly Create _create;
        private readonly Read _read;
        private readonly Update _update;
        private readonly Delete _delete;

        public Application(
            ApplicationDbContext dbContext,
            MainMenu mainMenu,
            Create create,
            Read read,
            Update update,
            Delete delete)
        {
            _dbContext = dbContext;
            _mainMenu = mainMenu;
            _create = create;
            _read = read;
            _update = update;
            _delete = delete;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                var userMainMenuChoice = _mainMenu.DisplayMainMenu();

                switch (userMainMenuChoice)
                {
                    case 1:
                        _create.RunCreate();
                        break;
                    case 2:
                        _read.RunRead();
                        break;
                    case 3:
                        _update.RunUpdate();
                        break;
                    case 4:
                        _delete.RunDelete();
                        break;
                    default:
                        Console.WriteLine("Error. Enter a correct number! Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
