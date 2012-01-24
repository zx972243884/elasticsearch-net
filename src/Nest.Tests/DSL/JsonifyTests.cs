﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nest.DSL;
using Nest;
using Newtonsoft.Json.Converters;
using Nest.Resolvers.Converters;
using Nest.TestData.Domain;

namespace Nest.Tests.DSL
{
	[TestFixture]
	public class JsonifyTests
	{
		public JsonifyTests()
		{
			
		}


		private bool JsonEquals(string json, string otherjson)
		{
			var nJson = JObject.Parse(json).ToString();
			var nOtherJson = JObject.Parse(otherjson).ToString();
			return nJson == nOtherJson;
		}

		[Test]
		public void TestFromSize()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10);
			var json = ElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10 }";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestSkipTake()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.Skip(0)
				.Take(10);
			var json = ElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10 }";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestBasics()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.Skip(0)
				.Take(10)
				.Explain()
				.Version()
				.MinScore(0.4);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ 
				from: 0, size: 10,
				explain: true, 
				version: true,
				min_score: 0.4
			}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestBasicsIndicesBoost()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.Skip(0)
				.Take(10)
				.Explain()
				.Version()
				.MinScore(0.4)
				.IndicesBoost(b=>b.Add("index1",1.4).Add("index2", 1.3));
				;
			var json = ElasticClient.Serialize(s);
			var expected = @"{ 
				from: 0, size: 10,
				explain: true, 
				version: true,
				min_score: 0.4,
				indices_boost : {
					index1 : 1.4,
					index2 : 1.3
				}

			}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestPreference()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Preference("_primary");
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, preference: ""_primary"" }";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestExecuteOnPrimary()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.ExecuteOnPrimary();
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, preference: ""_primary"" }";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestExecuteOnLocalShard()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.ExecuteOnLocalShard();
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, preference: ""_local"" }";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestExecuteOnNode()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.ExecuteOnNode("somenode");
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				preference: ""_only_node:somenode"" }";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestFields()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Fields(e=>e.Id, e=>e.Name);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
				fields: [""id"", ""name""]
				}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestSort()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Fields(e => e.Id, e => e.Name)
				.SortAscending(e=>e.LOC);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
					sort: {
						""loc.sort"": ""asc""
					},
					fields: [""id"", ""name""]
				}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestSortDescending()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Fields(e => e.Id, e => e.Name)
				.SortAscending(e => e.LOC)
				.SortDescending(e => e.Name);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, 
					sort: {
						""loc.sort"": ""asc"",
						""name.sort"": ""desc""
					},
					fields: [""id"", ""name""]
				}";
			Assert.True(this.JsonEquals(json, expected));
		}

		[Test]
		public void TestSuperSimpleQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q=> q);
			var json = ElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10, query : {}}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestMatchAllQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q.MatchAll());
			var json = ElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10, query : { match_all: {}}}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestMatchAllShortcut()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.MatchAll();
			var json = ElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10, query : { match_all: {}}}";
			Assert.True(this.JsonEquals(json, expected));
		}

		[Test]
		public void TestMatchAllWithBoostQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.MatchAll(Boost:1.2)
				);
			var json = ElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10, query : { match_all: { boost: 1.2 }}}";
			Assert.True(this.JsonEquals(json, expected));
		}

		[Test]
		public void TestMatchAllWithNormFieldQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.MatchAll(NormField: "name")
				);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : { match_all: { norm_field: ""name"" }}}";
			Assert.True(this.JsonEquals(json, expected));
		}

		[Test]
		public void TestTermQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.Term(f => f.Name, "elasticsearch.pm")
				);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : 
			{ term: { name : { value : ""elasticsearch.pm"" } }}}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestTermWithBoostQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.Term(f => f.Name, "elasticsearch.pm", Boost: 1.2)
				);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : 
			{ term: { name : { value : ""elasticsearch.pm"", boost: 1.2 } }}}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestWildcardQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.Wildcard(f => f.Name, "elasticsearch.*")
				);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : 
			{ wildcard: { name : { value : ""elasticsearch.*"" } }}}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestWildcardWithBoostQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.Wildcard(f => f.Name, "elasticsearch.*", Boost: 1.2)
				);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : 
			{ wildcard: { name : { value : ""elasticsearch.*"", boost: 1.2 } }}}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestPrefixQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.Prefix(f => f.Name, "elasticsearch.*")
				);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : 
			{ prefix: { name : { value : ""elasticsearch.*"" } }}}";
			Assert.True(this.JsonEquals(json, expected));
		}
		[Test]
		public void TestPrefixWithBoostQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.Prefix(f => f.Name, "el", Boost: 1.2)
				);
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : 
			{ prefix: { name : { value : ""el"", boost: 1.2 } }}}";
			Assert.True(this.JsonEquals(json, expected));
		}

		[Test]
		public void TestRawQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(@"{ raw : ""query""}");
			var json = ElasticClient.Serialize(s);
			var expected = @"{ from: 0, size: 10, query : { raw : ""query""}}";
			Assert.True(this.JsonEquals(json, expected));
		}
    [Test]
    public void TestRawFilter()
    {
      var s = new SearchDescriptor<ElasticSearchProject>()
        .From(0)
        .Size(10)
        .Filter(@"{ raw : ""query""}");
      var json = ElasticClient.Serialize(s);
      var expected = @"{ from: 0, size: 10, filter : { raw : ""query""}}";
      Assert.True(this.JsonEquals(json, expected));
    }
    [Test]
    public void TestRawFilterAndQuery()
    {
      var s = new SearchDescriptor<ElasticSearchProject>()
        .From(0)
        .Size(10)
        .Filter(@"{ raw : ""query""}")
        .Query(@"{ raw : ""query""}");
      var json = ElasticClient.Serialize(s);
      var expected = @"{ from: 0, size: 10, query : { raw : ""query""}, filter : { raw : ""query""}}";
      Assert.True(this.JsonEquals(json, expected));
    }
    [Test]
    public void TestTermFacet()
    {
      var s = new SearchDescriptor<ElasticSearchProject>()
        .From(0)
        .Size(10)
        .Query(@"{ raw : ""query""}")
        .FacetTerm(f=>f.Country, f=> f.Size(20));
      var json = ElasticClient.Serialize(s);
      var expected = @"{ from: 0, size: 10, 
          facets :  {
            country :  {
                terms : {
                    field : ""country"",
                    size : 20
                } 
            }
          }, query : { raw : ""query""}
      }";
      Assert.True(this.JsonEquals(json, expected));
    }


		/*
		[Test]
		public void TestSuperSimpleQuery()
		{
			var s = new SearchDescriptor<ElasticSearchProject>()
				.From(0)
				.Size(10)
				.Query(q => q
					.Term(e=>e.Name, "nest", boost: 1.0)
					.Bool(b=>b
						.Must(m=> m
							.Term(e => e.Name, "nest", boost: 1.0)
						)
						.MustNot(m=>m
							.Term(e => e.Name, "nest12", boost: 1.0)
						)
						.Should(s=>s
							.Term(e => e.Name, "nestle", boost: 1.0)
						)
						.MinimumNumberShouldMatch(1)
						.Boost(1.0)
					)
				);
			var json = ElasticClient.Serialize(s);
			var expected = "{ from: 0, size: 10, query : {}}";
			Assert.True(this.JsonEquals(json, expected));
		}*/
	}
}
