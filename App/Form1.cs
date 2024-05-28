using algorithm;

namespace App
{
    public partial class Form1 : Form
    {
        private List<Node> nodes;

        private static int idNode;
        private static string message = "";
        private static bool stateNode = true;

        public Form1()
        {
            InitializeComponent();
            nodes = new List<Node>(7);
            Conect();
        }

        private void sendClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Panel parentPanel = clickedButton.Parent as Panel;
                if (parentPanel != null)
                {
                    Label nodeLabel = parentPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name.StartsWith("node"));
                    if (nodeLabel != null)
                    {
                        string nodeId = nodeLabel.Name.Substring(4);
                        idNode = Int32.Parse(nodeId);

                        changeParameters();
                    }
                }
            }
        }

        private void activateClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Panel parentPanel = clickedButton.Parent as Panel;
                if (parentPanel != null)
                {
                    Label nodeLabel = parentPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name.StartsWith("node"));
                    if (nodeLabel != null)
                    {
                        string nodeId = nodeLabel.Name.Substring(4);
                        idNode = Int32.Parse(nodeId);
                        stateNode = true;
                        statusNode();
                    }
                }
            }
        }

        private void deactivateClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Panel parentPanel = clickedButton.Parent as Panel;
                if (parentPanel != null)
                {
                    Label nodeLabel = parentPanel.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Name.StartsWith("node"));
                    if (nodeLabel != null)
                    {
                        string nodeId = nodeLabel.Name.Substring(4);
                        idNode = Int32.Parse(nodeId);
                        stateNode = false;
                        statusNode();
                    }
                }
            }
        }

        private void Start(object sender, EventArgs e)
        {
            startAlgorithm();
        }

        private void Conect()
        {
            string[] part1 = node2.Text.Split(' ');
            string[] part2 = node12.Text.Split(' ');
            string[] part3 = node10.Text.Split(' ');
            string[] part4 = node3.Text.Split(' ');
            string[] part5 = node6.Text.Split(' ');
            string[] part6 = node18.Text.Split(' ');
            string[] part7 = node7.Text.Split(' ');

            nodes.Add(new Node(Int32.Parse(part1[1])));
            nodes.Add(new Node(Int32.Parse(part2[1])));
            nodes.Add(new Node(Int32.Parse(part3[1])));
            nodes.Add(new Node(Int32.Parse(part4[1])));
            nodes.Add(new Node(Int32.Parse(part5[1])));
            nodes.Add(new Node(Int32.Parse(part6[1])));
            nodes.Add(new Node(Int32.Parse(part7[1])));

            nodes[0].nextNode = nodes[1];
            nodes[1].nextNode = nodes[2];
            nodes[2].nextNode = nodes[3];
            nodes[3].nextNode = nodes[4];
            nodes[4].nextNode = nodes[5];
            nodes[5].nextNode = nodes[6];
            nodes[6].nextNode = nodes[0];
        }

        private void changeParameters()
        {
            for (byte i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].id == idNode && stateNode == true)
                {
                    //MessageBox.Show($"Node: {nodes[i].id}");
                    //MessageBox.Show($"status: {nodes[i].isActive}");

                }
                else if(nodes[i].id == idNode && stateNode == false)
                {
                    //MessageBox.Show($"Node: {nodes[i].id}");
                    //MessageBox.Show($"status: {nodes[i].isActive}");
                }
            }
        }


        private void statusNode()
        {
            for (byte i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].id == idNode && stateNode == true)
                {
                    nodes[i].isActive = stateNode;

                    string labelName = $"conect{idNode}";
                    Label connectLabel = Controls.Find(labelName, true).FirstOrDefault() as Label;

                    if (connectLabel != null)
                    {
                        if (stateNode)
                        {
                            connectLabel.Text = "Conectado";
                            connectLabel.ForeColor = Color.Green;
                        }
                        else
                        {
                            connectLabel.Text = "Desconectado";
                            connectLabel.ForeColor = Color.Red;
                        }
                    }
                }
                else if (nodes[i].id == idNode && stateNode == false)
                {
                    nodes[i].isActive = stateNode;

                    string labelName = $"conect{idNode}";
                    Label connectLabel = Controls.Find(labelName, true).FirstOrDefault() as Label;

                    if (connectLabel != null)
                    {
                        if (stateNode)
                        {
                            connectLabel.Text = "Conectado";
                            connectLabel.ForeColor = Color.Green;
                        }
                        else
                        {
                            connectLabel.Text = "Desconectado";
                            connectLabel.ForeColor = Color.Red;
                        }
                    }
                }

            }
        }

        public void startAlgorithm()
        {
            int highestId = -1;
            Node coordinatorNode = null;

            foreach (var node in nodes)
            {
                if (node.isActive && node.id > highestId)
                {
                    highestId = node.id;
                    coordinatorNode = node;

                }
                searchColor(node.id);
                Thread.Sleep(500);
                MessageBox.Show($"Node {node.id}.");
            }

            if (coordinatorNode != null)
            {
                foreach (var node in nodes)
                {
                    node.isCoordinator = (node.id == highestId);
                    if (node.isCoordinator)
                    {
                        node.message = "Coordinator";
                        colorCordinator(node.id);
                        //MessageBox.Show($"Node {node.id} is the coordinator.");
                    }
                    else
                    {
                        node.message = "";
                    }
                }
            }
        }


        private void colorCordinator(int number) 
        {
            string panelName;
            Panel panelCordinator;

            List<int> listId = new List<int>(nodes.Count);

            for (byte i = 0;  i < nodes.Count; i++)
            {
                listId.Add(nodes[i].id);


                if (nodes[i].isActive == true && nodes[i].isCoordinator == true && listId[i] == number)
                {
                    panelName = $"panel{nodes[i].id}";
                    panelCordinator = Controls.Find(panelName, true).FirstOrDefault() as Panel;
                    panelCordinator.BackColor = Color.DarkOrange;
                }
                else
                {
                    panelName = $"panel{nodes[i].id}";
                    panelCordinator = Controls.Find(panelName, true).FirstOrDefault() as Panel;
                    panelCordinator.BackColor = Color.Silver;
                }
            }
        }

        private void searchColor(int number)
        {
            string panelName = $"panel{number}";
            Panel panelSearch = Controls.Find(panelName, true).FirstOrDefault() as Panel;
            panelSearch.BackColor = Color.Green;
        }
    }
}
