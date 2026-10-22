using System;
using System.Windows.Forms;
using BookkeepingApp.Interfaces;
using BookkeepingApp.Repositories;
using BookkeepingApp.Services;

namespace BookkeepingApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Instantiate the standalone file services
            IFeeService feeService = new FileFeeService();
            IBookRepository bookRepo = new JsonBookRepository(feeService);
            IRentalRepository rentalRepo = new JsonRentalRepository(feeService);

            // 2. Inject them into the main form
            Application.Run(new MainForm(bookRepo, rentalRepo));
        }
    }
}