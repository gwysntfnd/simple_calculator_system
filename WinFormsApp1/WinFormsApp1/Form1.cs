namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Double resultValue = 0; //Contains the result value
        String operationPerformed = "" ; //Contains the operator
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }
        //Will be perform when the buttons will be clicked.
        private void button_click(object sender, EventArgs e)
        {
            //To remove the 0 when button was clicked.
            if ((textBox_Result.Text == "0") || (isOperationPerformed)) //added condition for continue performing the operation
            {
                textBox_Result.Clear();
                isOperationPerformed = false ; //store if the operation is performed or not
            }
            //When the button was click the number will display on the textbox.
            Button button = (Button)sender;
            //Will prevent inputing lots of decimal point.
            if (button.Text == ".") //text from the button
            {
                if (!textBox_Result.Text.Contains(".")) //if text doesn't contains decimal
                    textBox_Result.Text = textBox_Result.Text + button.Text;// then provide, otherwise dont
            }
            else
            textBox_Result.Text = textBox_Result.Text + button.Text;
        }
        //This will get the operator need to perform
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //continue performing operations on numbers, continous input
            if (resultValue != 0) {
                button11.PerformClick();//replicate operation
                operationPerformed = button.Text;
                label2.Text = resultValue + " " + operationPerformed; //sets the current number and operator to the label
                isOperationPerformed = true;
            }
            else {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text); 
                label2.Text = resultValue + " " + operationPerformed; //sets the current number and operator to the label
                isOperationPerformed = true;
            }

        }

        //This will perform the operations.
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                switch (operationPerformed)
                {
                    case "+": //addition
                        textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "-": //subtraction
                        textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "*": //multiplication
                        textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "/"://division
                        textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    case "%"://modulo
                        textBox_Result.Text = (resultValue % Double.Parse(textBox_Result.Text)).ToString();
                        break;
                    default:
                        break;
                }
                resultValue = Double.Parse(textBox_Result.Text);
                label2.Text = "";
            }
            //Catch possible error
            catch (Exception ex) { 
            MessageBox.Show("Error Occured: " + ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        //Deletes the numbers on the text box
        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }
        //Deletes All/Reset
        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            textBox_Result.Text = "0";
            resultValue = 0;
        }
        //Deletes 1 number only
        private void button19_Click(object sender, EventArgs e)
        {
            string temp = textBox_Result.Text;
            if (temp.Length != 0)
            {
                textBox_Result.Text = temp.Substring(1);
            }

        }
        //Greetings
        private void button21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Catcoolator!", "Catcoolator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Exit Application or Continue
        private void button22_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Thank you for using this app!", "Catcoolator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}