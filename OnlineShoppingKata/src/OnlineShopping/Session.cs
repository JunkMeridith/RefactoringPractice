using System.Collections.Generic;
using System.Text;

namespace OnlineShopping
{
    public class Session
    {
        private readonly Dictionary<string, ModelObject> _session;

        public Session() {
            _session = new Dictionary<string, ModelObject>
            {
                {"CART", new Cart()}, 
                {"LOCATION_SERVICE", new LocationService()}
            };
        }

        public ModelObject Get(string key) {
            return _session[key];
        }

        public void Put(string key, ModelObject value) {
            if (_session.ContainsKey(key))
                _session[key] = value;
            else
                _session.Add(key, value);
        }

        public virtual void SaveAll() {
            foreach (string key in _session.Keys) {
                var entity = _session[key];
                entity?.SaveToDatabase();
            }
        }

        public override string ToString() {
            var sessionContents = new StringBuilder("\n");
            foreach (string key in _session.Keys) {
                sessionContents.Append(key);
                sessionContents.Append("=");
                ModelObject modelObject = _session[key];
                sessionContents.Append(modelObject);
                sessionContents.Append("\n");
            }

            return "Session{" +
                   sessionContents +
                   "}";
        }
    }
}