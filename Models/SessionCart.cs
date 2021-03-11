﻿using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Assignment5.Infrastructure;
using Assignment5.Models;

namespace Assignment5.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Project project, int quantity)
        {
            base.AddItem(project, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Project project)
        {
            base.RemoveLine(project);
            Session.SetJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
