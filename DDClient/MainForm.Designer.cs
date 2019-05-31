namespace DDClient
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CodeEditor = new System.Windows.Forms.RichTextBox();
            this.FunctionsComboBox = new System.Windows.Forms.ComboBox();
            this.TableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayout.Controls.Add(this.MainChart, 1, 0);
            this.TableLayout.Controls.Add(this.CodeEditor, 0, 0);
            this.TableLayout.Controls.Add(this.FunctionsComboBox, 0, 1);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 2;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableLayout.Size = new System.Drawing.Size(1282, 498);
            this.TableLayout.TabIndex = 0;
            // 
            // MainChart
            // 
            this.MainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainChart.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.Text;
            chartArea1.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MainChart.Legends.Add(legend1);
            this.MainChart.Location = new System.Drawing.Point(503, 3);
            this.MainChart.Name = "MainChart";
            this.TableLayout.SetRowSpan(this.MainChart, 2);
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.MainChart.Series.Add(series1);
            this.MainChart.Size = new System.Drawing.Size(776, 492);
            this.MainChart.TabIndex = 0;
            // 
            // CodeEditor
            // 
            this.CodeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeEditor.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeEditor.Location = new System.Drawing.Point(3, 3);
            this.CodeEditor.Name = "CodeEditor";
            this.CodeEditor.Size = new System.Drawing.Size(494, 392);
            this.CodeEditor.TabIndex = 1;
            this.CodeEditor.Text = "";
            this.CodeEditor.TextChanged += new System.EventHandler(this.CodeEditor_TextChanged);
            // 
            // FunctionsComboBox
            // 
            this.FunctionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FunctionsComboBox.FormattingEnabled = true;
            this.FunctionsComboBox.Location = new System.Drawing.Point(3, 401);
            this.FunctionsComboBox.Name = "FunctionsComboBox";
            this.FunctionsComboBox.Size = new System.Drawing.Size(494, 21);
            this.FunctionsComboBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 498);
            this.Controls.Add(this.TableLayout);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.TableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.RichTextBox CodeEditor;
        private System.Windows.Forms.ComboBox FunctionsComboBox;
    }
}

