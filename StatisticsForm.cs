using System;
using System.Drawing;
using System.Windows.Forms;
using BookkeepingApp.Services;

namespace BookkeepingApp
{
    public partial class StatisticsForm : Form
    {
        private readonly JsonStatisticsService _statsService;
        private Label lblTotalRentals;
        private Label lblTotalFees;
        private Label lblMostPopular;
        private Label lblBusiestDay;

        public StatisticsForm()
        {
            _statsService = new JsonStatisticsService();
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = "Store Statistics";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(20),
                AutoScroll = true
            };

            lblTotalRentals = CreateStatLabel();
            lblTotalFees = CreateStatLabel();
            lblMostPopular = CreateStatLabel();
            lblBusiestDay = CreateStatLabel();

            panel.Controls.Add(lblTotalRentals);
            panel.Controls.Add(lblTotalFees);
            panel.Controls.Add(lblMostPopular);
            panel.Controls.Add(lblBusiestDay);

            this.Controls.Add(panel);
        }

        private Label CreateStatLabel()
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                Margin = new Padding(0, 0, 0, 15)
            };
        }

        private async void LoadData()
        {
            var stats = await _statsService.GetStatisticsAsync();

            lblTotalRentals.Text = $"📚 Total Rentals All-Time: {stats.TotalAllTimeRentals}";
            lblTotalFees.Text = $"💰 Total Late Fees Collected: ${stats.TotalLateFeesCollected:0.00}";
            lblMostPopular.Text = $"⭐ Most Popular Book:\n    {stats.MostPopularBook}";
            lblBusiestDay.Text = $"🔥 Busiest Rental Day:\n    {stats.BusiestRentalDay}";
        }
    }
}