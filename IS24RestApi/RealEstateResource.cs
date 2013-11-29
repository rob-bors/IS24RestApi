﻿using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace IS24RestApi
{
    /// <summary>
    /// The resource responsible for managing real estate data
    /// </summary>
    public class RealEstateResource : IRealEstateResource
    {
        private readonly IIS24Connection connection;

        /// <summary>
        /// Creates a new <see cref="RealEstateResource"/> instance
        /// </summary>
        /// <param name="connection"></param>
        public RealEstateResource(IIS24Connection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Get all RealEstate objects as an observable sequence.
        /// </summary>
        /// <returns>The RealEstate objects.</returns>
        public IObservable<RealEstate> GetAsync()
        {
            return Observable.Create<RealEstate>(
                async o =>
                {
                    var page = 1;

                    while (true)
                    {
                        var req = connection.CreateRequest("realestate");
                        req.AddParameter("pagesize", 100);
                        req.AddParameter("pagenumber", page);
                        var rel = await connection.ExecuteAsync<realEstates>(req);

                        foreach (var ore in rel.realEstateList)
                        {
                            var oreq = connection.CreateRequest("realestate/{id}");
                            oreq.AddParameter("id", ore.id, ParameterType.UrlSegment);
                            var re = await connection.ExecuteAsync<RealEstate>(oreq);
                            o.OnNext(re);
                        }

                        if (page >= rel.Paging.numberOfPages) break;
                        page++;
                    }
                });
        }

        /// <summary>
        /// Gets a single RealEstate object identified by the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="isExternal">true if the id is an external id.</param>
        /// <returns>The RealEstate object or null.</returns>
        public Task<RealEstate> GetAsync(string id, bool isExternal = false)
        {
            var req = connection.CreateRequest("realestate/{id}");
            req.AddParameter("id", isExternal ? "ext-" + id : id, ParameterType.UrlSegment);
            return connection.ExecuteAsync<RealEstate>(req);
        }

        /// <summary>
        /// Creates a RealEstate object.
        /// </summary>
        /// <param name="re">The RealEstate object.</param>
        public async Task CreateAsync(RealEstate re)
        {
            var req = connection.CreateRequest("realestate", Method.POST);
            req.AddBody(re);
            var resp = await connection.ExecuteAsync<messages>(req);
            var id = resp.ExtractCreatedResourceId();
            if (!id.HasValue)
            {
                throw new IS24Exception(string.Format("Error creating RealEstate {0}: {1}", re.externalId, resp.message.ToMessage())) { Messages = resp };
            }
            re.id = id.Value;
            re.idSpecified = true;
        }

        /// <summary>
        /// Updates a RealEstate object.
        /// </summary>
        /// <param name="re">The RealEstate object.</param>
        public async Task UpdateAsync(RealEstate re)
        {
            var req = connection.CreateRequest("realestate/{id}", Method.PUT);
            req.AddParameter("id", re.id, ParameterType.UrlSegment);
            req.AddBody(re);
            var messages = await connection.ExecuteAsync<messages>(req);
            if (!messages.IsSuccessful())
            {
                throw new IS24Exception(string.Format("Error updating RealEstate {0}: {1}", re.externalId, messages.message.ToMessage())) { Messages = messages };
            }
        }
    }
}