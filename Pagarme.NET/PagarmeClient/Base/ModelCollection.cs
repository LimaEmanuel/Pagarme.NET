﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

#if HAS_ASYNC
using System.Threading.Tasks;
#endif

namespace PagarmeClient.Base
{
    public class ModelCollection<TModel> where TModel : Model
    {
        private PagarMeService _service;
        private string _endpoint;

        internal ModelCollection(string endpoint)
            : this(null, endpoint)
        {

        }

        internal ModelCollection(PagarMeService service, string endpoint)
        {
            if (service == null)
                service = PagarMeService.GetDefaultService();

            _service = service;
            _endpoint = endpoint;
        }

        public TModel Find(int id, bool load = true)
        {
            return Find(id.ToString(), load);
        }

        public TModel Find(string id, bool load = true)
        {
            var model = (TModel)Activator.CreateInstance(typeof(TModel), new object[] { _service });

            if (load)
                model.Refresh(id);
            else
                model.SetId(id);

            return model;
        }

        #if HAS_ASYNC
        public Task<TModel> FindAsync(int id, bool load = true)
        {
            return FindAsync(id.ToString(), load);
        }

        public async Task<TModel> FindAsync(string id, bool load = true)
        {
            var model = (TModel)Activator.CreateInstance(typeof(TModel), new object[] { _service });

            if (load)
                await model.RefreshAsync(id);
            else
                model.SetId(id);

            return model;
        }
        #endif

        public TModel Find(TModel searchParams)
        {
            return FindAll(searchParams).FirstOrDefault();
        }

        public async Task<TModel> FindAsync(TModel searchParams)
        {
            return (await FindAllAsync(searchParams)).FirstOrDefault();
        }
            
        public IEnumerable<TModel> FindAll(TModel searchParams)
        {
            return FinishFindQuery(BuildFindQuery(searchParams).Execute());
        }

        public async Task<IEnumerable<TModel>> FindAllAsync(TModel searchParams)
        {
            return FinishFindQuery(await BuildFindQuery(searchParams).ExecuteAsync());
        }

        public PagarMeRequest BuildFindQuery(TModel searchParameters)
        {
            var request = new PagarMeRequest(_service, "GET", _endpoint);
            var keys = searchParameters.GetKeys(SerializationType.Plain);

            BuildQueryForKeys(request.Query, null, keys);

            return request;
        }

        public void BuildQueryForKeys(List<Tuple<string, string>> query, string prefix, IDictionary<string, object> keys)
        {
            foreach (var kvp in keys)
            {
                var name = "";

                if (prefix == null)
                {
                    name = kvp.Key;
                }
                else
                {
                    name = prefix + "[" + kvp.Key + "]";
                }

                if (kvp.Value is IDictionary<string, object>)
                {
                    BuildQueryForKeys(query, name, (IDictionary<string, object>)kvp.Value);
                }
                else if (kvp.Value is String)
                {
                    query.Add(new Tuple<string, string>(name, kvp.Value.ToString()));
                }
                else
                {
                    query.Add(new Tuple<string, string>(name, JValue.FromObject(kvp.Value).ToString(Newtonsoft.Json.Formatting.None)));
                }
            }
        }

        public IEnumerable<TModel> FinishFindQuery(PagarMeResponse response)
        {
            return JArray.Parse(response.Body).Select((x) =>
                {
                    var model = (TModel)Activator.CreateInstance(typeof(TModel), new object[] { _service });

                    model.LoadFrom((JObject)x);

                    return model;
                });
 
        }
    }
}

