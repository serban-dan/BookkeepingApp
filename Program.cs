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

            // 1. Instantiate the standalone text file services
            IFeeService feeService = new FileFeeService();
            IBookRepository bookRepo = new TextBookRepository(feeService);
            IRentalRepository rentalRepo = new TextRentalRepository(feeService);

            // 2. Inject them into the main form
            Application.Run(new MainForm(bookRepo, rentalRepo));
        }
    }
}