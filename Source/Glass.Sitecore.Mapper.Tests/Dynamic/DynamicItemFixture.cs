﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Glass.Sitecore.Mapper.Configuration.Attributes;
using Sitecore.Data;
using Glass.Sitecore.Mapper.Dynamic;
using Sitecore.Data.Items;
using Glass.Sitecore.Mapper.Tests.Domain;

namespace Glass.Sitecore.Mapper.Tests.Dynamic
{
    [TestFixture]
    public class DynamicItemFixture
    {

        Database _db;

        [SetUp]
        public void Setup()
        {
            _db = global::Sitecore.Configuration.Factory.GetDatabase("master");

            global::Sitecore.Context.Site = global::Sitecore.Sites.SiteContext.GetSite("website");
        }

        #region

        [Test]
        public void DynamicFields_ReturnsFields()
        {
            //Assign
            Item item = _db.GetItem("/sitecore/content/DynamicItem/Test");

            dynamic d = new DynamicItem(item);

            //Act
            string dateTime = d.DateTime;

            string text = d.SingleLineText;


            //Assert
            Assert.AreEqual("some awesome dynamic content", text);
            Assert.AreEqual("15/02/2012 02:30:00", dateTime);
        }

        [Test]
        public void DynamicInfo_ReturnsItemInfo()
        {
            //Assign
            Item item = _db.GetItem("/sitecore/content/DynamicItem/Test");

            dynamic d = new DynamicItem(item);

            //Act
            string path = d.Path;
            string name = d.Name;

            //Assert
            Assert.AreEqual("/sitecore/content/DynamicItem/Test", path);
            Assert.AreEqual("Test", name);


        }

        [Test]
        public void DynamicParent_ReturnsParent()
        {
            //Assign
            Item item = _db.GetItem("/sitecore/content/DynamicItem/Test");

            dynamic d = new DynamicItem(item);

            //Act
            var parent = d.Parent;
            string path = parent.Path;

            //Assert
            Assert.AreEqual("/sitecore/content/DynamicItem", path);

        }

        [Test]
        public void DynamicParent_ReturnsChildren()
        {
            //Assign
            Item item = _db.GetItem("/sitecore/content/DynamicItem/Test");

            dynamic d = new DynamicItem(item);

            //Act

            var children = d.Children;

            //Assert
            Assert.AreEqual(3, children.Count());

            foreach (var child in d.Children)
            {
                string path = child.Path;
                Assert.IsTrue(path.StartsWith("/sitecore/content/DynamicItem/Test/"));
            }
        }

        [Test]
        public void DynamicParent_ReturnsLastChild()
        {
            //Assign
            Item item = _db.GetItem("/sitecore/content/DynamicItem/Test");

            dynamic d = new DynamicItem(item);

            //Act

            var children = d.Children;

            //Assert
            Assert.AreEqual(3, children.Count());

            var child = d.Children.Last();

                string path = child.Path;
                Assert.IsTrue(path.StartsWith("/sitecore/content/DynamicItem/Test/"));
        }
        #endregion
    }


}
