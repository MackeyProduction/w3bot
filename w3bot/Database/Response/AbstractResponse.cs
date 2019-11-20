using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using w3bot.Database.Factory;

namespace w3bot.Database.Response
{
    internal abstract class AbstractResponse
    {
        internal async Task<AbstractResponseModel> GetResponse(HttpResponseMessage httpResponseMessage)
        {
            try
            {
                var data = await httpResponseMessage.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(data);

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return onSuccess(result);
                }

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden || httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound || httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Conflict || httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show((string)result.response);
                }

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Error connecting to server.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        protected abstract AbstractResponseModel onSuccess(dynamic data);
    }
}
