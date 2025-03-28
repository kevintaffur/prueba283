﻿using System.Net.Http.Headers;
using System.Text;
using front.Dtos.Productos;
using front.Models;
using front.Utils.Responses;
using Newtonsoft.Json;
using NuGet.Common;

namespace front.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient Client;
        private readonly string BaseUrl;

        public ProductoService(HttpClient httpClient)
        {
            Client = httpClient;
            BaseUrl = Environment.GetEnvironmentVariable("ApiBase") + "/productos";
        }

        public async Task<bool> CrearProducto(ProductoCreacionDto productoCreacionDto, string token)
        {
            string json = JsonConvert.SerializeObject(productoCreacionDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await Client.PostAsync($"{BaseUrl}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarProducto(int id, ProductoModificacionDto productoModificacionDto, string token)
        {
            string json = JsonConvert.SerializeObject(productoModificacionDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await Client.PutAsync($"{BaseUrl}/{id}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<Producto> ObtenerProductoPorId(int id, string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await Client.GetAsync($"{BaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string content = await response.Content.ReadAsStringAsync();
            ProductoResponse productoResponse = JsonConvert.DeserializeObject<ProductoResponse>(content);

            return productoResponse.Content;
        }

        public async Task<List<Producto>> ObtenerProductos(string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await Client.GetAsync(BaseUrl);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string content = await response.Content.ReadAsStringAsync();
            ProductoListResponse productoListResponse = JsonConvert.DeserializeObject<ProductoListResponse>(content);

            return productoListResponse.Content;
        }
    }
}
