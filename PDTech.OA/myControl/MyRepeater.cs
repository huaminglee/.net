using System;
using System.Web.UI;

[assembly: TagPrefix("myControl", "Zore")]
namespace myControl
{
    public class Repeater : System.Web.UI.WebControls.Repeater
    {
        private ITemplate emptyDataTemplate;

        [PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(TemplateControl))]
        public ITemplate EmptyDataTemplate
        {
            get { return emptyDataTemplate; }
            set { emptyDataTemplate = value; }
        }
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            if (emptyDataTemplate != null)
            {
                if (this.Items.Count == 0)
                {
                    EmptyDataTemplate.InstantiateIn(this);
                }
            }
        }
    }
}