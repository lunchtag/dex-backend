/*
* Digital Excellence Copyright (C) 2020 Brend Smits
* 
* This program is free software: you can redistribute it and/or modify 
* it under the terms of the GNU Lesser General Public License as published 
* by the Free Software Foundation version 3 of the License.
* 
* This program is distributed in the hope that it will be useful, 
* but WITHOUT ANY WARRANTY; without even the implied warranty 
* of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
* See the GNU Lesser General Public License for more details.
* 
* You can find a copy of the GNU Lesser General Public License 
* along with this program, in the LICENSE.md file in the root project directory.
* If not, see https://www.gnu.org/licenses/lgpl-3.0.txt
*/

using System.ComponentModel.DataAnnotations;

namespace JobScheduler
{

    /// <summary>
    ///     This is the configuration class.
    /// </summary>
    public class Config
    {

        /// <summary>
        ///     This gets or sets the identity server configuration
        /// </summary>
        public IdentityServerConfig IdentityServerConfig { get; set; }

        /// <summary>
        ///     This gets or sets the api configuration
        /// </summary>
        public ApiConfig ApiConfig { get; set; }

        /// <summary>
        ///     This gets or sets the job scheduler configuration
        /// </summary>
        public JobSchedulerConfig JobSchedulerConfig { get; set; }

        /// <summary>
        ///     This gets or sets the rabbit MQ configuration.
        /// </summary>
        public RabbitMQ RabbitMQ { get; set; }

    }

    /// <summary>
    ///     This is the configuration of the identity server
    /// </summary>
    public class IdentityServerConfig
    {

        /// <summary>
        ///     This gets or sets the identity url
        /// </summary>
        public string IdentityUrl { get; set; }

        /// <summary>
        ///     This gets or sets the client id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     This gets or sets the client secret
        /// </summary>
        public string ClientSecret { get; set; }

    }

    /// <summary>
    ///     This is the configuration of the Api
    /// </summary>
    public class ApiConfig
    {

        public string ApiUrl { get; set; }

    }

    /// <summary>
    ///     This is the configuration for the Job scheduler
    /// </summary>
    public class JobSchedulerConfig
    {

        /// <summary>
        ///     Expected graduating user will be achieved between now and TimeRange (amount of months)
        /// </summary>
        public int TimeRange { get; set; }

        /// <summary>
        ///     Time between jobs in milliseconds
        /// </summary>
        public int TimeBetweenJobsInMs { get; set; }

    }

    /// <summary>
    ///     Contains the RabbitMQConfig configuration.
    /// </summary>
    public class RabbitMQ
    {

        /// <summary>
        ///     Gets or sets the hostname.
        /// </summary>
        /// <value>
        ///     The hostname.
        /// </value>
        [Required]
        public string Hostname { get; set; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>
        ///     The username.
        /// </value>
        [Required]
        public string Username { get; set; }

        /// <summary>
        ///     Gets or sets the password.
        /// </summary>
        /// <value>
        ///     The password.
        /// </value>
        [Required]
        public string Password { get; set; }

    }

}
