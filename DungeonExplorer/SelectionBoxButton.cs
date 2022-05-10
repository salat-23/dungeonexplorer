namespace DungeonExplorer
{
    public class SelectionBoxButton
    {
        public string Text { get; set; }
        public object Metadata { get; set; }

        public SelectionBoxButton(string text, object metadata)
        {
            Text = text;
            Metadata = metadata;
        }
    }
}