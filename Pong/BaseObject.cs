namespace Pong
{
    public abstract class BaseObject
    {
        public string Name { get; private set; }

        protected BaseObject(string name)
        {
            Name = name;
        }
    }
}