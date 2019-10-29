﻿using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;

namespace Firebase.Analytics
{
	// @interface FIRAnalytics : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRAnalytics")]
	interface Analytics
	{
		// +(void)logEventWithName:(NSString * _Nonnull)name parameters:(NSDictionary<NSString *,NSObject *> * _Nullable)parameters;
		[Static]
		[Export ("logEventWithName:parameters:")]
		void LogEvent (string name, [NullAllowed] NSDictionary<NSString, NSObject> nsParameters);

		[Static]
		[Wrap ("LogEvent (name, parameters == null ? null : parameters.Keys.Count == 0 ? new NSDictionary<NSString, NSObject> () : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (parameters.Values), System.Linq.Enumerable.ToArray (parameters.Keys), parameters.Keys.Count))")]
		void LogEvent (string name, [NullAllowed] Dictionary<object, object> parameters);

		// +(void)setUserPropertyString:(NSString * _Nullable)value forName:(NSString * _Nonnull)name;
		[Static]
		[Export ("setUserPropertyString:forName:")]
		void SetUserProperty ([NullAllowed] string value, string name);

		// +(void)setUserID:(NSString * _Nullable)userID;
		[Static]
		[Export ("setUserID:")]
		void SetUserId ([NullAllowed] string userId);

		// + (void)setScreenName:(nullable NSString *)screenName screenClass:(nullable NSString *)screenClassOverride;
		[Static]
		[Export ("setScreenName:screenClass:")]
		void SetScreenNameAndClass ([NullAllowed] string screenName, [NullAllowed] string screenClassOverride);

		// +(void)setAnalyticsCollectionEnabled:(BOOL)analyticsCollectionEnabled;
		[Static]
		[Export ("setAnalyticsCollectionEnabled:")]
		void SetAnalyticsCollectionEnabled (bool analyticsCollectionEnabled);

		// +(void)setSessionTimeoutInterval:(NSTimeInterval)sessionTimeoutInterval;
		[Static]
		[Export ("setSessionTimeoutInterval:")]
		void SetSessionTimeoutInterval (double sessionTimeoutInterval);

		// + (NSString *)appInstanceID;
		[Static]
		[Export ("appInstanceID")]
		string AppInstanceId { get; }

		// + (void)resetAnalyticsData;
		[Static]
		[Export ("resetAnalyticsData")]
		void ResetAnalyticsData ();

		///
		/// This method comes from a category (FIRAnalytics+AppDelegate.h)
		///

		// +(void)handleEventsForBackgroundURLSession:(NSString *)identifier completionHandler:(void (^)(void))completionHandler;
		[Static]
		[Export ("handleEventsForBackgroundURLSession:completionHandler:")]
		void HandleEventsForBackgroundUrlSession (string identifier, [NullAllowed] Action completionHandler);

		// +(void)handleOpenURL:(NSURL *)url;
		[Static]
		[Export ("handleOpenURL:")]
		void HandleOpenUrl (NSUrl url);

		// +(void)handleUserActivity:(id)userActivity;
		[Static]
		[Export ("handleUserActivity:")]
		void HandleUserActivity (NSObject userActivity);
	}
}
