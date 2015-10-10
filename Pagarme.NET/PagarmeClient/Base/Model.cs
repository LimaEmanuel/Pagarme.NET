using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PagarmeClient.Base
{
    public abstract class Model : AbstractModel
    {
        public string Id
        {
            get
            {
                var result = GetAttribute<object>("id");

                if (result == null)
                    return null;

                return result.ToString();
            }
            set { SetAttribute("id", value); }
        }

        private Model()
            : this(null)
        {
        }

        protected Model(PagarMeService service)
            : base(service)
        {
        }

        public void ExecuteSelfRequest(PagarMeRequest request)
        {
            LoadFrom(request.Execute().Body);
        }

        public async Task ExecuteSelfRequestAsync(PagarMeRequest request)
        {
            LoadFrom((await request.ExecuteAsync()).Body);
        }

        public void Refresh()
        {
            Refresh(Id);
        }

        internal void Refresh(string id)
        {
            if (id == null)
                throw new InvalidOperationException("Cannot refresh not existing object.");

            var request = CreateCollectionRequest("GET", "/" + id);
            var response = request.Execute();

            LoadFrom(response.Body);
        }

        #if HAS_ASYNC
        public async Task RefreshAsync()
        {
            await RefreshAsync(Id);
        }

        internal async Task RefreshAsync(string id)
        {
            if (id == null)
                throw new InvalidOperationException("Cannot refresh not existing object.");

            var request = CreateCollectionRequest("GET", "/" + id);
            var response = await request.ExecuteAsync();

            LoadFrom(response.Body);
        }
        #endif

        public void Save()
        {
            if (Id == null)
            {
                var request = CreateCollectionRequest("POST");

                request.Body = ToJson(SerializationType.Full);

                var response = request.Execute();

                LoadFrom(response.Body);
            }
            else
            {
                var request = CreateRequest("PUT");

                request.Body = ToJson(SerializationType.Shallow);

                var response = request.Execute();

                LoadFrom(response.Body);
            }
        }

        #if HAS_ASYNC
        public async Task SaveAsync()
        {
            if (Id == null)
            {
                var request = CreateCollectionRequest("POST");

                request.Body = ToJson(SerializationType.Full);

                var response = await request.ExecuteAsync();

                LoadFrom(response.Body);
            }
            else
            {
                var request = CreateRequest("PUT");

                request.Body = ToJson(SerializationType.Shallow);

                var response = await request.ExecuteAsync();

                LoadFrom(response.Body);
            }
        }
        #endif

        protected PagarMeRequest CreateRequest(string method, string endpoint = "")
        {
            return new PagarMeRequest(Service, method, Endpoint + "/" + Id + endpoint);
        }

        protected PagarMeRequest CreateCollectionRequest(string method, string endpoint = "")
        {
            return new PagarMeRequest(Service, method, Endpoint + endpoint);
        }

        internal void SetId(string id)
        {
            Id = id;
        }

        protected virtual bool CanSave()
        {
            return true;
        }

        protected abstract string Endpoint { get; }
    }
}

