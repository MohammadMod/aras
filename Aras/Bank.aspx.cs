using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aras
{
    public partial class Bank : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

                TreeView treeView = new TreeView();
                treeView.ID = "parent";
                treeView.ExpandDepth = 1;
                treeView.ExpandAll();

                TreeNode treeNode = new TreeNode();
                treeNode.Text = "Parent";
                treeNode.Value = "Node 1";
                treeNode.Expanded = true;

            TreeNode tnChild = new TreeNode();
            tnChild.Text = "Child";
            treeNode.ChildNodes.Add(tnChild);

        
           
         
                treeView.Nodes.Add(treeNode);

                form1.Controls.Add(treeView);
            
        }

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            
        }
    }
}