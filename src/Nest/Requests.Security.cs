// ███╗   ██╗ ██████╗ ████████╗██╗ ██████╗███████╗
// ████╗  ██║██╔═══██╗╚══██╔══╝██║██╔════╝██╔════╝
// ██╔██╗ ██║██║   ██║   ██║   ██║██║     █████╗
// ██║╚██╗██║██║   ██║   ██║   ██║██║     ██╔══╝
// ██║ ╚████║╚██████╔╝   ██║   ██║╚██████╗███████╗
// ╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝ ╚═════╝╚══════╝
// -----------------------------------------------
//
// This file is automatically generated
// Please do not edit these files manually
// Run the following in the root of the repos:
//
// 		*NIX 		:	./build.sh codegen
// 		Windows 	:	build.bat codegen
//
// -----------------------------------------------
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.Specification.SecurityApi;
using Nest.Utf8Json;

// ReSharper disable RedundantBaseConstructorCall
// ReSharper disable UnusedTypeParameter
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
namespace Nest
{
	[InterfaceDataContract]
	public partial interface IAuthenticateRequest : IRequest<AuthenticateRequestParameters>
	{
	}

	///<summary>Request for Authenticate <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-authenticate.html</para></summary>
	public partial class AuthenticateRequest : PlainRequestBase<AuthenticateRequestParameters>, IAuthenticateRequest
	{
		protected IAuthenticateRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityAuthenticate;
	// values part of the url path
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IChangePasswordRequest : IRequest<ChangePasswordRequestParameters>
	{
		[IgnoreDataMember]
		Name Username
		{
			get;
		}
	}

	///<summary>Request for ChangePassword <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-change-password.html</para></summary>
	public partial class ChangePasswordRequest : PlainRequestBase<ChangePasswordRequestParameters>, IChangePasswordRequest
	{
		protected IChangePasswordRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityChangePassword;
		///<summary>/_security/user/{username}/_password</summary>
		///<param name = "username">Optional, accepts null</param>
		public ChangePasswordRequest(Name username): base(r => r.Optional("username", username))
		{
		}

		///<summary>/_security/user/_password</summary>
		public ChangePasswordRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IChangePasswordRequest.Username => Self.RouteValues.Get<Name>("username");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IClearCachedPrivilegesRequest : IRequest<ClearCachedPrivilegesRequestParameters>
	{
		[IgnoreDataMember]
		Names Application
		{
			get;
		}
	}

	///<summary>Request for ClearCachedPrivileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-privilege-cache.html</para></summary>
	public partial class ClearCachedPrivilegesRequest : PlainRequestBase<ClearCachedPrivilegesRequestParameters>, IClearCachedPrivilegesRequest
	{
		protected IClearCachedPrivilegesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityClearCachedPrivileges;
		///<summary>/_security/privilege/{application}/_clear_cache</summary>
		///<param name = "application">this parameter is required</param>
		public ClearCachedPrivilegesRequest(Names application): base(r => r.Required("application", application))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ClearCachedPrivilegesRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names IClearCachedPrivilegesRequest.Application => Self.RouteValues.Get<Names>("application");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IClearCachedRealmsRequest : IRequest<ClearCachedRealmsRequestParameters>
	{
		[IgnoreDataMember]
		Names Realms
		{
			get;
		}
	}

	///<summary>Request for ClearCachedRealms <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-cache.html</para></summary>
	public partial class ClearCachedRealmsRequest : PlainRequestBase<ClearCachedRealmsRequestParameters>, IClearCachedRealmsRequest
	{
		protected IClearCachedRealmsRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityClearCachedRealms;
		///<summary>/_security/realm/{realms}/_clear_cache</summary>
		///<param name = "realms">this parameter is required</param>
		public ClearCachedRealmsRequest(Names realms): base(r => r.Required("realms", realms))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ClearCachedRealmsRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names IClearCachedRealmsRequest.Realms => Self.RouteValues.Get<Names>("realms");
		// Request parameters
		///<summary>Comma-separated list of usernames to clear from the cache</summary>
		public string[] Usernames
		{
			get => Q<string[]>("usernames");
			set => Q("usernames", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IClearCachedRolesRequest : IRequest<ClearCachedRolesRequestParameters>
	{
		[IgnoreDataMember]
		Names Name
		{
			get;
		}
	}

	///<summary>Request for ClearCachedRoles <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-clear-role-cache.html</para></summary>
	public partial class ClearCachedRolesRequest : PlainRequestBase<ClearCachedRolesRequestParameters>, IClearCachedRolesRequest
	{
		protected IClearCachedRolesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityClearCachedRoles;
		///<summary>/_security/role/{name}/_clear_cache</summary>
		///<param name = "name">this parameter is required</param>
		public ClearCachedRolesRequest(Names name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected ClearCachedRolesRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names IClearCachedRolesRequest.Name => Self.RouteValues.Get<Names>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface ICreateApiKeyRequest : IRequest<CreateApiKeyRequestParameters>
	{
	}

	///<summary>Request for CreateApiKey <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-create-api-key.html</para></summary>
	public partial class CreateApiKeyRequest : PlainRequestBase<CreateApiKeyRequestParameters>, ICreateApiKeyRequest
	{
		protected ICreateApiKeyRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityCreateApiKey;
		// values part of the url path
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IDeletePrivilegesRequest : IRequest<DeletePrivilegesRequestParameters>
	{
		[IgnoreDataMember]
		Name Application
		{
			get;
		}

		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for DeletePrivileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-privilege.html</para></summary>
	public partial class DeletePrivilegesRequest : PlainRequestBase<DeletePrivilegesRequestParameters>, IDeletePrivilegesRequest
	{
		protected IDeletePrivilegesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityDeletePrivileges;
		///<summary>/_security/privilege/{application}/{name}</summary>
		///<param name = "application">this parameter is required</param>
		///<param name = "name">this parameter is required</param>
		public DeletePrivilegesRequest(Name application, Name name): base(r => r.Required("application", application).Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeletePrivilegesRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IDeletePrivilegesRequest.Application => Self.RouteValues.Get<Name>("application");
		[IgnoreDataMember]
		Name IDeletePrivilegesRequest.Name => Self.RouteValues.Get<Name>("name");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IDeleteRoleRequest : IRequest<DeleteRoleRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for DeleteRole <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role.html</para></summary>
	public partial class DeleteRoleRequest : PlainRequestBase<DeleteRoleRequestParameters>, IDeleteRoleRequest
	{
		protected IDeleteRoleRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityDeleteRole;
		///<summary>/_security/role/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public DeleteRoleRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteRoleRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IDeleteRoleRequest.Name => Self.RouteValues.Get<Name>("name");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IDeleteRoleMappingRequest : IRequest<DeleteRoleMappingRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for DeleteRoleMapping <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-role-mapping.html</para></summary>
	public partial class DeleteRoleMappingRequest : PlainRequestBase<DeleteRoleMappingRequestParameters>, IDeleteRoleMappingRequest
	{
		protected IDeleteRoleMappingRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityDeleteRoleMapping;
		///<summary>/_security/role_mapping/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public DeleteRoleMappingRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteRoleMappingRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IDeleteRoleMappingRequest.Name => Self.RouteValues.Get<Name>("name");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IDeleteUserRequest : IRequest<DeleteUserRequestParameters>
	{
		[IgnoreDataMember]
		Name Username
		{
			get;
		}
	}

	///<summary>Request for DeleteUser <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-delete-user.html</para></summary>
	public partial class DeleteUserRequest : PlainRequestBase<DeleteUserRequestParameters>, IDeleteUserRequest
	{
		protected IDeleteUserRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityDeleteUser;
		///<summary>/_security/user/{username}</summary>
		///<param name = "username">this parameter is required</param>
		public DeleteUserRequest(Name username): base(r => r.Required("username", username))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DeleteUserRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IDeleteUserRequest.Username => Self.RouteValues.Get<Name>("username");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IDisableUserRequest : IRequest<DisableUserRequestParameters>
	{
		[IgnoreDataMember]
		Name Username
		{
			get;
		}
	}

	///<summary>Request for DisableUser <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-disable-user.html</para></summary>
	public partial class DisableUserRequest : PlainRequestBase<DisableUserRequestParameters>, IDisableUserRequest
	{
		protected IDisableUserRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityDisableUser;
		///<summary>/_security/user/{username}/_disable</summary>
		///<param name = "username">this parameter is required</param>
		public DisableUserRequest(Name username): base(r => r.Required("username", username))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected DisableUserRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IDisableUserRequest.Username => Self.RouteValues.Get<Name>("username");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IEnableUserRequest : IRequest<EnableUserRequestParameters>
	{
		[IgnoreDataMember]
		Name Username
		{
			get;
		}
	}

	///<summary>Request for EnableUser <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-enable-user.html</para></summary>
	public partial class EnableUserRequest : PlainRequestBase<EnableUserRequestParameters>, IEnableUserRequest
	{
		protected IEnableUserRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityEnableUser;
		///<summary>/_security/user/{username}/_enable</summary>
		///<param name = "username">this parameter is required</param>
		public EnableUserRequest(Name username): base(r => r.Required("username", username))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected EnableUserRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IEnableUserRequest.Username => Self.RouteValues.Get<Name>("username");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IGetApiKeyRequest : IRequest<GetApiKeyRequestParameters>
	{
	}

	///<summary>Request for GetApiKey <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-api-key.html</para></summary>
	public partial class GetApiKeyRequest : PlainRequestBase<GetApiKeyRequestParameters>, IGetApiKeyRequest
	{
		protected IGetApiKeyRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetApiKey;
		// values part of the url path
		// Request parameters
		///<summary>API key id of the API key to be retrieved</summary>
		public string Id
		{
			get => Q<string>("id");
			set => Q("id", value);
		}

		///<summary>API key name of the API key to be retrieved</summary>
		public string Name
		{
			get => Q<string>("name");
			set => Q("name", value);
		}

		///<summary>flag to query API keys owned by the currently authenticated user</summary>
		public bool? Owner
		{
			get => Q<bool? >("owner");
			set => Q("owner", value);
		}

		///<summary>realm name of the user who created this API key to be retrieved</summary>
		public string RealmName
		{
			get => Q<string>("realm_name");
			set => Q("realm_name", value);
		}

		///<summary>user name of the user who created this API key to be retrieved</summary>
		public string Username
		{
			get => Q<string>("username");
			set => Q("username", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IGetBuiltinPrivilegesRequest : IRequest<GetBuiltinPrivilegesRequestParameters>
	{
	}

	///<summary>Request for GetBuiltinPrivileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-builtin-privileges.html</para></summary>
	public partial class GetBuiltinPrivilegesRequest : PlainRequestBase<GetBuiltinPrivilegesRequestParameters>, IGetBuiltinPrivilegesRequest
	{
		protected IGetBuiltinPrivilegesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetBuiltinPrivileges;
	// values part of the url path
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IGetPrivilegesRequest : IRequest<GetPrivilegesRequestParameters>
	{
		[IgnoreDataMember]
		Name Application
		{
			get;
		}

		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for GetPrivileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-privileges.html</para></summary>
	public partial class GetPrivilegesRequest : PlainRequestBase<GetPrivilegesRequestParameters>, IGetPrivilegesRequest
	{
		protected IGetPrivilegesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetPrivileges;
		///<summary>/_security/privilege</summary>
		public GetPrivilegesRequest(): base()
		{
		}

		///<summary>/_security/privilege/{application}</summary>
		///<param name = "application">Optional, accepts null</param>
		public GetPrivilegesRequest(Name application): base(r => r.Optional("application", application))
		{
		}

		///<summary>/_security/privilege/{application}/{name}</summary>
		///<param name = "application">Optional, accepts null</param>
		///<param name = "name">Optional, accepts null</param>
		public GetPrivilegesRequest(Name application, Name name): base(r => r.Optional("application", application).Optional("name", name))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IGetPrivilegesRequest.Application => Self.RouteValues.Get<Name>("application");
		[IgnoreDataMember]
		Name IGetPrivilegesRequest.Name => Self.RouteValues.Get<Name>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IGetRoleRequest : IRequest<GetRoleRequestParameters>
	{
		[IgnoreDataMember]
		Names Name
		{
			get;
		}
	}

	///<summary>Request for GetRole <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role.html</para></summary>
	public partial class GetRoleRequest : PlainRequestBase<GetRoleRequestParameters>, IGetRoleRequest
	{
		protected IGetRoleRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetRole;
		///<summary>/_security/role/{name}</summary>
		///<param name = "name">Optional, accepts null</param>
		public GetRoleRequest(Names name): base(r => r.Optional("name", name))
		{
		}

		///<summary>/_security/role</summary>
		public GetRoleRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names IGetRoleRequest.Name => Self.RouteValues.Get<Names>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IGetRoleMappingRequest : IRequest<GetRoleMappingRequestParameters>
	{
		[IgnoreDataMember]
		Names Name
		{
			get;
		}
	}

	///<summary>Request for GetRoleMapping <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-role-mapping.html</para></summary>
	public partial class GetRoleMappingRequest : PlainRequestBase<GetRoleMappingRequestParameters>, IGetRoleMappingRequest
	{
		protected IGetRoleMappingRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetRoleMapping;
		///<summary>/_security/role_mapping/{name}</summary>
		///<param name = "name">Optional, accepts null</param>
		public GetRoleMappingRequest(Names name): base(r => r.Optional("name", name))
		{
		}

		///<summary>/_security/role_mapping</summary>
		public GetRoleMappingRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names IGetRoleMappingRequest.Name => Self.RouteValues.Get<Names>("name");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IGetUserAccessTokenRequest : IRequest<GetUserAccessTokenRequestParameters>
	{
	}

	///<summary>Request for GetUserAccessToken <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-token.html</para></summary>
	public partial class GetUserAccessTokenRequest : PlainRequestBase<GetUserAccessTokenRequestParameters>, IGetUserAccessTokenRequest
	{
		protected IGetUserAccessTokenRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetUserAccessToken;
	// values part of the url path
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IGetUserRequest : IRequest<GetUserRequestParameters>
	{
		[IgnoreDataMember]
		Names Username
		{
			get;
		}
	}

	///<summary>Request for GetUser <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-user.html</para></summary>
	public partial class GetUserRequest : PlainRequestBase<GetUserRequestParameters>, IGetUserRequest
	{
		protected IGetUserRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetUser;
		///<summary>/_security/user/{username}</summary>
		///<param name = "username">Optional, accepts null</param>
		public GetUserRequest(Names username): base(r => r.Optional("username", username))
		{
		}

		///<summary>/_security/user</summary>
		public GetUserRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Names IGetUserRequest.Username => Self.RouteValues.Get<Names>("username");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IGetUserPrivilegesRequest : IRequest<GetUserPrivilegesRequestParameters>
	{
	}

	///<summary>Request for GetUserPrivileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-get-privileges.html</para></summary>
	public partial class GetUserPrivilegesRequest : PlainRequestBase<GetUserPrivilegesRequestParameters>, IGetUserPrivilegesRequest
	{
		protected IGetUserPrivilegesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetUserPrivileges;
	// values part of the url path
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IHasPrivilegesRequest : IRequest<HasPrivilegesRequestParameters>
	{
		[IgnoreDataMember]
		Name User
		{
			get;
		}
	}

	///<summary>Request for HasPrivileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-has-privileges.html</para></summary>
	public partial class HasPrivilegesRequest : PlainRequestBase<HasPrivilegesRequestParameters>, IHasPrivilegesRequest
	{
		protected IHasPrivilegesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityHasPrivileges;
		///<summary>/_security/user/_has_privileges</summary>
		public HasPrivilegesRequest(): base()
		{
		}

		///<summary>/_security/user/{user}/_has_privileges</summary>
		///<param name = "user">Optional, accepts null</param>
		public HasPrivilegesRequest(Name user): base(r => r.Optional("user", user))
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IHasPrivilegesRequest.User => Self.RouteValues.Get<Name>("user");
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IInvalidateApiKeyRequest : IRequest<InvalidateApiKeyRequestParameters>
	{
	}

	///<summary>Request for InvalidateApiKey <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-api-key.html</para></summary>
	public partial class InvalidateApiKeyRequest : PlainRequestBase<InvalidateApiKeyRequestParameters>, IInvalidateApiKeyRequest
	{
		protected IInvalidateApiKeyRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityInvalidateApiKey;
	// values part of the url path
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IInvalidateUserAccessTokenRequest : IRequest<InvalidateUserAccessTokenRequestParameters>
	{
	}

	///<summary>Request for InvalidateUserAccessToken <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-invalidate-token.html</para></summary>
	public partial class InvalidateUserAccessTokenRequest : PlainRequestBase<InvalidateUserAccessTokenRequestParameters>, IInvalidateUserAccessTokenRequest
	{
		protected IInvalidateUserAccessTokenRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityInvalidateUserAccessToken;
	// values part of the url path
	// Request parameters
	}

	[InterfaceDataContract]
	public partial interface IPutPrivilegesRequest : IRequest<PutPrivilegesRequestParameters>
	{
	}

	///<summary>Request for PutPrivileges <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-privileges.html</para></summary>
	public partial class PutPrivilegesRequest : PlainRequestBase<PutPrivilegesRequestParameters>, IPutPrivilegesRequest
	{
		protected IPutPrivilegesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityPutPrivileges;
		// values part of the url path
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IPutRoleRequest : IRequest<PutRoleRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for PutRole <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role.html</para></summary>
	public partial class PutRoleRequest : PlainRequestBase<PutRoleRequestParameters>, IPutRoleRequest
	{
		protected IPutRoleRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityPutRole;
		///<summary>/_security/role/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public PutRoleRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PutRoleRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IPutRoleRequest.Name => Self.RouteValues.Get<Name>("name");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IPutRoleMappingRequest : IRequest<PutRoleMappingRequestParameters>
	{
		[IgnoreDataMember]
		Name Name
		{
			get;
		}
	}

	///<summary>Request for PutRoleMapping <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-role-mapping.html</para></summary>
	public partial class PutRoleMappingRequest : PlainRequestBase<PutRoleMappingRequestParameters>, IPutRoleMappingRequest
	{
		protected IPutRoleMappingRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityPutRoleMapping;
		///<summary>/_security/role_mapping/{name}</summary>
		///<param name = "name">this parameter is required</param>
		public PutRoleMappingRequest(Name name): base(r => r.Required("name", name))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PutRoleMappingRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IPutRoleMappingRequest.Name => Self.RouteValues.Get<Name>("name");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IPutUserRequest : IRequest<PutUserRequestParameters>
	{
		[IgnoreDataMember]
		Name Username
		{
			get;
		}
	}

	///<summary>Request for PutUser <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-put-user.html</para></summary>
	public partial class PutUserRequest : PlainRequestBase<PutUserRequestParameters>, IPutUserRequest
	{
		protected IPutUserRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityPutUser;
		///<summary>/_security/user/{username}</summary>
		///<param name = "username">this parameter is required</param>
		public PutUserRequest(Name username): base(r => r.Required("username", username))
		{
		}

		///<summary>Used for serialization purposes, making sure we have a parameterless constructor</summary>
		[SerializationConstructor]
		protected PutUserRequest(): base()
		{
		}

		// values part of the url path
		[IgnoreDataMember]
		Name IPutUserRequest.Username => Self.RouteValues.Get<Name>("username");
		// Request parameters
		///<summary>
		/// If `true` (the default) then refresh the affected shards to make this operation visible to search, if `wait_for` then wait for a refresh
		/// to make this operation visible to search, if `false` then do nothing with refreshes.
		///</summary>
		public Refresh? Refresh
		{
			get => Q<Refresh? >("refresh");
			set => Q("refresh", value);
		}
	}

	[InterfaceDataContract]
	public partial interface IGetCertificatesRequest : IRequest<GetCertificatesRequestParameters>
	{
	}

	///<summary>Request for GetCertificates <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/security-api-ssl.html</para></summary>
	public partial class GetCertificatesRequest : PlainRequestBase<GetCertificatesRequestParameters>, IGetCertificatesRequest
	{
		protected IGetCertificatesRequest Self => this;
		internal override ApiUrls ApiUrls => ApiUrlsLookups.SecurityGetCertificates;
	// values part of the url path
	// Request parameters
	}
}
