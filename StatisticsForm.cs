using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BookkeepingApp.Models;
using BookkeepingApp.Services;

namespace BookkeepingApp
{
    public partial class StatisticsForm : Form
    {
        private readonly JsonStatisticsService _statsService;
        private StoreStatistics _stats;

        private Label lblTotalRentals;
        private Label lblTotalFees;
        private Label lblMostPopular;
        private Label lblBusiestDay;
        private Panel pnlChart;

        public StatisticsForm()
        {
            _statsService = new JsonStatisticsService();
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            this.Text = "Store Analytics Dashboard";
            this.Size = new Size(850, 500); // Much wider to fit the graph
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 245); // Light dashboard gray

            // LEFT SIDE: Summary Panel
            var pnlSummary = new FlowLayoutPanel
            {
                Location = new Point(20, 20),
                Size = new Size(300, 420),
                FlowDirection = FlowDirection.TopDown,
                BackColor = Color.White,
                Padding = new Padding(15),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label { Text = "Performance Overview", Font = new Font("Segoe UI", 14, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 0, 0, 20) };
            lblTotalRentals = CreateStatLabel();
            lblTotalFees = CreateStatLabel();
            lblMostPopular = CreateStatLabel();
            lblBusiestDay = CreateStatLabel();

            pnlSummary.Controls.Add(lblTitle);
            pnlSummary.Controls.Add(lblTotalRentals);
            pnlSummary.Controls.Add(lblTotalFees);
            pnlSummary.Controls.Add(lblMostPopular);
            pnlSummary.Controls.Add(lblBusiestDay);

            // RIGHT SIDE: Chart Panel (This acts as our canvas)
            pnlChart = new Panel
            {
                Location = new Point(340, 20),
                Size = new Size(470, 420),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Wire up the paint event where the actual drawing happens
            pnlChart.Paint += PnlChart_Paint;

            this.Controls.Add(pnlSummary);
            this.Controls.Add(pnlChart);
        }

        private static Label CreateStatLabel()
        {
            return new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Margin = new Padding(0, 0, 0, 25),
                MaximumSize = new Size(270, 0) // Allows text wrapping for long book titles
            };
        }

        private async void LoadData()
        {
            _stats = await _statsService.GetStatisticsAsync();

            lblTotalRentals.Text = $"📚 Total Rentals All-Time:\n{_stats.TotalAllTimeRentals}";
            lblTotalFees.Text = $"💰 Total Late Fees Collected:\n${_stats.TotalLateFeesCollected:0.00}";
            lblMostPopular.Text = $"⭐ Most Popular Book:\n{_stats.MostPopularBook}";
            lblBusiestDay.Text = $"🔥 Busiest Rental Day:\n{_stats.BusiestRentalDay}";

            // Trigger the panel to redraw itself now that we have data
            pnlChart.Invalidate();
        }

        // The graphics engine draws the bar chart here
        private void PnlChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Makes text and shapes look smooth

            // Draw Chart Title
            g.DrawString("Top 5 Rented Books", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.DarkSlateBlue, 20, 20);

            if (_stats == null || _stats.Top5Books.Count == 0)
            {
                g.DrawString("Not enough rental history to generate chart.", new Font("Segoe UI", 11, FontStyle.Italic), Brushes.Gray, 20, 60);
                return;
            }

            int maxRentals = _stats.Top5Books.Values.Max();
            if (maxRentals == 0) maxRentals = 1;

            int y = 70;
            int barHeight = 40;
            int spacing = 25;
            int maxBarWidth = 250; // Maximum length a bar can reach

            foreach (var kvp in _stats.Top5Books)
            {
                // 1. Draw the Book Title (Truncated if too long)
                string title = kvp.Key.Length > 22 ? kvp.Key[..20] + "..." : kvp.Key;
                g.DrawString(title, new Font("Segoe UI", 10), Brushes.Black, 20, y + 10);

                // 2. Calculate proportional bar width based on the highest rental count
                int barWidth = (int)((double)kvp.Value / maxRentals * maxBarWidth);
                if (barWidth < 5) barWidth = 5; // Minimum size so it's visible

                // 3. Draw the colored bar
                Rectangle barRect = new Rectangle(170, y, barWidth, barHeight);
                using (var brush = new SolidBrush(Color.FromArgb(100, 149, 237))) // Cornflower Blue
                {
                    g.FillRectangle(brush, barRect);
                }

                // 4. Draw the number value inside/next to the bar
                int textX = 170 + barWidth + 10;
                g.DrawString(kvp.Value.ToString(), new Font("Segoe UI", 10, FontStyle.Bold), Brushes.DarkSlateBlue, textX, y + 10);

                y += barHeight + spacing;
            }
        }
    }
}