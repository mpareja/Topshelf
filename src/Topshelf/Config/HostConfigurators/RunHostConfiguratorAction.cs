﻿// Copyright 2007-2011 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Topshelf.HostConfigurators
{
	using System;
	using Builders;
	using Internal;


	public class RunHostConfiguratorAction :
		HostBuilderConfigurator
	{
		readonly Action<RunBuilder> _callback;

		public RunHostConfiguratorAction(Action<RunBuilder> callback)
		{
			_callback = callback;
		}

		public void Validate()
		{
			if (_callback == null)
				throw new HostConfigurationException("A null callback was specified");
		}

		public HostBuilder Configure([NotNull] HostBuilder builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			builder.Match<RunBuilder>(x => _callback(x));

			return builder;
		}
	}
}