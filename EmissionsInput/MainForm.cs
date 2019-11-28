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
        public Source[] sources;
        public Sensor[] sensors;

        public MainForm()
        {
            InitializeComponent();
            sources = InitialSources();
            sensors = InitialSensors();
        }

        private Source[] InitialSources()
        {
            Source src1 = new Source()
            {
                pniv = 1
            };

            Source src2 = new Source()
            {
                pniv = 2
            };

            return new Source[] { src1, src2 };
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
            /*try
            {
                Value val = new Value()
                {
                    value = valueTextBox.Text
                };

                Parameter param = new Parameter()
                {
                    code = parameterTextBox.Text,
                    unit = "kg",
                    type = "string"
                };

                param.values.Append(val);

                sensors[sensorsDropDown.SelectedIndex].parameters.Append(param);
                sources[sourcesDropDown.SelectedIndex].sensors.Append(sensors[sensorsDropDown.SelectedIndex]);
            }
            catch
            {
                MessageBox.Show(
                    "Заполните все поля",
                    "Ошибка заполнения формы",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }*/

            DataAccess db = new DataAccess();

            db.InsertMySource(Guid.NewGuid().ToString(), Int32.Parse(parameterTextBox.Text));

            List<MySource> sources = db.GetMySensors();
            valueTextBox.Text = sources.Last().SourceUuid;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sourcesDropDown.Items.AddRange(sources);
            sensorsDropDown.Items.AddRange(sensors);
        }
    }
}
