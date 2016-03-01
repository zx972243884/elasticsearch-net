﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using FluentAssertions;
using Nest;
using Tests.Framework;

namespace Tests.ClientConcepts.LowLevel
{
	public class PostingData
	{
		/** ## Post data
		 * The low level allows you to post a string, byte[] array directly. On top of this if you pass a list of strings or objects
		 * they will be serialized in Elasticsearch's special bulk/multi format.
		 */
		private readonly string @string = "fromString";
		private readonly byte[] bytes = Utf8Bytes("fromByteArray");
		private List<string> listOfStrings = Enumerable.Range(0, 5).Select(i => i.ToString()).ToList();
		private List<object> listOfObjects;
		private object @object;

		private byte[] multiStringJson;
		private byte[] multiObjectJson;
		private byte[] objectJson;

		public PostingData()
		{
			this.@object = new { my_object = "value" };
			this.listOfObjects = Enumerable.Range(0, 5).Select(i => @object).Cast<object>().ToList();
			var json = "{\"my_object\":\"value\"}";
			this.objectJson = Utf8Bytes(json);
			this.multiStringJson = Utf8Bytes(string.Join("\n", listOfStrings) + "\n");
			this.multiObjectJson = Utf8Bytes(string.Join("\n", listOfObjects.Select(o=> json)) + "\n");
		}

		[U] public void ImplicitConversions()
		{
			/** Even though the argument for postData on the low level client takes a PostData
			* You can rely on C# implicit conversion to abstract the notion of PostData completely.
			*You can implicitly convert from the following types.*/

			var fromString = ImplicitlyConvertsFrom(@string);
			var fromByteArray = ImplicitlyConvertsFrom(bytes);
			var fromListOfString = ImplicitlyConvertsFrom(listOfStrings);
			var fromListOfObject = ImplicitlyConvertsFrom(listOfObjects);
			var fromObject = ImplicitlyConvertsFrom(@object);

			/** postData Bytes will always be set if it originated from a byte*/
			fromByteArray.WrittenBytes.Should().BeSameAs(bytes);

			fromString.Type.Should().Be(PostType.LiteralString);
			fromByteArray.Type.Should().Be(PostType.ByteArray);
			fromListOfString.Type.Should().Be(PostType.EnumerableOfString);
			fromListOfObject.Type.Should().Be(PostType.EnumerableOfObject);
			fromObject.Type.Should().Be(PostType.Serializable);
			
			//passing a PostData<object> object to a method taking PostData<object> should not wrap

			fromString = ImplicitlyConvertsFrom(fromString);
			fromByteArray = ImplicitlyConvertsFrom(fromByteArray);
			fromListOfString = ImplicitlyConvertsFrom(fromListOfString);
			fromListOfObject = ImplicitlyConvertsFrom(fromListOfObject);
			fromObject = ImplicitlyConvertsFrom(fromObject);

			fromString.Type.Should().Be(PostType.LiteralString);
			fromByteArray.Type.Should().Be(PostType.ByteArray);
			fromListOfString.Type.Should().Be(PostType.EnumerableOfString);
			fromListOfObject.Type.Should().Be(PostType.EnumerableOfObject);
			fromObject.Type.Should().Be(PostType.Serializable);


		}

		[U] public async Task WritesCorrectlyUsingBothLowAndHighLevelSettings()
		{
			await this.AssertOn(new ConnectionSettings());
			await this.AssertOn(new ConnectionConfiguration());
		}

		private async Task AssertOn(IConnectionConfigurationValues settings)
		{ 

			/** Although each implicitly types behaves slightly differently */
			await Post(()=>@string, writes: Utf8Bytes(@string), storesBytes: true, settings: settings);

			await Post(()=>bytes, writes: bytes, storesBytes: true, settings: settings);
			
			/** When passing a list of strings we assume its a list of valid serialized json that we 
			* join with newlinefeeds making sure there is a trailing linefeed */
			await Post(()=>listOfStrings, writes: multiStringJson, storesBytes: true, settings: settings);

			/**
			* When passing a list of object we assume its a list of objects we need to serialize
			* individually to json and join with newlinefeeds aking sure there is a trailing linefeed 
			*/
			await Post(()=>listOfObjects, writes: multiObjectJson, storesBytes: false, settings: settings);
			
			/** In all other cases postdata is serialized as is. */
			await Post(()=>@object, writes: objectJson, storesBytes: false, settings: settings);

			/** If you want to maintain a copy of the request that went out use the following settings */
			settings = new ConnectionSettings().DisableDirectStreaming();

			/** by forcing `DisableDirectStreaming` serializing happens first in a private MemoryStream 
			* so we can get a hold of the serialized bytes */
			await Post(()=>listOfObjects, writes: multiObjectJson, storesBytes: true, settings: settings);
			
			/** this behavior can also be observed when serializing a simple object using `DisableDirectStreaming` */
			await Post(()=>@object, writes: objectJson, storesBytes: true, settings: settings);
		}

		private static async Task Post(Func<PostData<object>> postData, byte[] writes, bool storesBytes, IConnectionConfigurationValues settings)
		{
			PostAssert(postData(), writes, storesBytes, settings);
			await PostAssertAsync(postData(), writes, storesBytes, settings);
		}

		private static void PostAssert(PostData<object> postData, byte[] writes, bool storesBytes, IConnectionConfigurationValues settings)
		{
			using (var ms = new MemoryStream())
			{
				postData.Write(ms, settings);
				var sentBytes = ms.ToArray();
				sentBytes.Should().Equal(writes);
				if (storesBytes)
					postData.WrittenBytes.Should().NotBeNull();
				else 
					postData.WrittenBytes.Should().BeNull();
			}
		}

		private static async Task PostAssertAsync(PostData<object> postData, byte[] writes, bool storesBytes, IConnectionConfigurationValues settings)
		{
			using (var ms = new MemoryStream())
			{
				await postData.WriteAsync(ms, settings);
				var sentBytes = ms.ToArray();
				sentBytes.Should().Equal(writes);
				if (storesBytes)
					postData.WrittenBytes.Should().NotBeNull();
				else 
					postData.WrittenBytes.Should().BeNull();
			}
		}

		private static byte[] Utf8Bytes(string s)
		{
			return string.IsNullOrEmpty(s) ? null : Encoding.UTF8.GetBytes(s);
		}
		private PostData<object> ImplicitlyConvertsFrom(PostData<object> postData) => postData;

	}
}
