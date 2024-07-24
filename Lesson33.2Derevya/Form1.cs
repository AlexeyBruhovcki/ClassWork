namespace Lesson33._2Derevya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTree_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                labelPath.Text = folderBrowserDialog1.SelectedPath;
                DirectoryInfo root = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                TreeNode child = new TreeNode(root.Name);
                PrintTree(child, root, 0);
            }

        }
        public void PrintTree(TreeNode parent, DirectoryInfo directory, int level)
        {
            treeViewList.Nodes.Clear();
            if (!checkBoxFiles.Checked)
            {
                DirectoryInfo[] directories = directory.GetDirectories();

                for (int i = 0; i < directories.Length; i++)
                {
                    TreeNode child = new TreeNode(directories[i].Name);
                    parent.Nodes.Add(child);
                    PrintTree(child, directories[i], level + 1);
                }
                if (level == 0)
                {
                    treeViewList.Nodes.Add(parent);
                }
            }
            else
            {
                DirectoryInfo[] directories = directory.GetDirectories();

                for (int i = 0; i < directories.Length; i++)
                {
                    TreeNode child = new TreeNode(directories[i].Name);
                    parent.Nodes.Add(child);
                    PrintTree(child, directories[i], level + 1);
                }
                string[] files = Directory.GetFiles(directory.FullName);
                for (int j = 0; j < files.Length; j++)
                {
                    FileInfo file = new FileInfo(files[j]);
                    parent.Nodes.Add(file.Name);
                }


                if (level == 0)
                {
                    treeViewList.Nodes.Add(parent);
                }
            }

        }

        private void checkBoxFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.SelectedPath.Length != 0)
            {
                labelPath.Text = folderBrowserDialog1.SelectedPath;
                DirectoryInfo root = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                TreeNode child = new TreeNode(root.Name);
                PrintTree(child, root, 0);
            }
        }

        private void treeViewList_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void treeViewList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            DirectoryInfo info = new DirectoryInfo(treeViewList.SelectedNode.Text);
            if (info.Extension.Length==0)
            {
                string text = info.FullName + "\n" + info.Attributes.ToString();
                label1.Text = text;
            }
            else
            {
                FileInfo file = new FileInfo(treeViewList.SelectedNode.Text);
                string text = file.FullName + "\n" + file.Attributes.ToString();
                label1.Text = text;
            }

        }
    }
}
