using Unity.UIWidgets.widgets;

namespace DocCN.Components
{
    public partial class ScriptingContent : StatefulWidget
    {
        public ScriptingContent(string title) : base(key: new ObjectKey(title))
        {
            _title = title;
        }
        private readonly string _title;
        public override State createState() => new ScriptingContentState();
    }
}