using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmissionsLibrary;

namespace EmissionsInput
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Source[] InitialSources()
        {
            Source src1 = new Source()
            {
                pniv = 1,
                sourceUuid = "source1"
            };

            Source src2 = new Source()
            {
                pniv = 2,
                sourceUuid = "source2"
            };

            return new Source[] { src1, src2};
        }

        private Sensor[] InitialSensors()
        {
            Sensor sns1 = new Sensor()
            {
                sensorUuid = "sensor1"
            };

            Sensor sns2 = new Sensor()
            {
                sensorUuid = "sensor2"
            };

            return new Sensor[] { sns1, sns2 };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Value val = new Value()
            {
                value = "21"
            };

            valueTextBox.Text = val.value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sourcesDropDown.Items.AddRange(InitialSources());
            sensorsDropDown.Items.AddRange(InitialSensors());
        }
    }
}
