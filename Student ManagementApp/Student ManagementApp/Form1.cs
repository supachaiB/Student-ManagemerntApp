using System.Text;

namespace Student_ManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);  
                string reaaAllText = File.ReadAllText(openFileDialog.FileName);
                
                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string studentRAW = readAllLine[i];
                    string[] studentSplited = studentRAW.Split(',');
                    Student student = new Student(studentSplited[0], studentSplited[1], studentSplited[2]);
                    addDataToGridView(studentSplited[0], studentSplited[1], studentSplited[2]);  
                }
               
            }

            void addDataToGridView(string id, string name, string major)
            {
                this.dataGridView1.Rows.Add(new string[] { id, name, major });
            }
        }
        
        
        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < outputCSV.Length; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        GPACalculator oGPACal = new GPACalculator();
        private void button1_Click(object sender, EventArgs e)
        {
            string input = this.textBoxGPA.Text;
            
            double dInput = Convert.ToDouble(input);
            oGPACal.addGPA(dInput);

            double gpax = oGPACal.getGPAx();
            textBoxGPAx.Text = gpax.ToString();
            

            double max = oGPACal.getMax();
            textBoxMaxGPA.Text = max.ToString();
            
            double min = oGPACal.getMin();
            textBoxMinGPA.Text = min.ToString();
           

            

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxID.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxName.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBoxMajor.Text;
            
            textBoxGPA.Text = "";
            textBoxName.Text = "";
            textBoxID.Text = "";
            comboBoxMajor.Text = "";

        }


    }
}