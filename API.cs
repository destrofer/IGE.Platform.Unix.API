/*
 * Author: Viacheslav Soroka
 * 
 * This file is part of IGE <https://github.com/destrofer/IGE>.
 * 
 * IGE is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * IGE is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 * along with IGE.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Text;
using System.Reflection;

using IGE;
using IGE.Platform;

namespace IGE.Platform.Unix {
	/// <summary>
	/// This is a singleton class. Making several instance of this class is useless.
	/// </summary>
	public sealed partial class API : IApiDriver {
		public string DriverName { get { return "Native Unix/Linux API"; } }
		public Version DriverVersion { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
		public bool IsSupported { get { return true; } }
		
		/// <summary>
		/// Contains the singleton instance of this class.
		/// </summary>
		internal static IGE.Platform.Unix.API Instance = null;
		public static IApiDriver GetInstance() {
			if( Instance != null )
				return Instance;
			return Instance = new IGE.Platform.Unix.API();
		}
		
		private API() {
		}
		
		public bool Initialize() {
			return true;
		}
		
		public bool Test() {
			return true;
		}

		public void RuntimeImport(Type type, GetProcAddressDelegate proc_address_get_func, object proc_address_get_func_param) {
			throw new NotImplementedException();
		}
		
		public void RuntimeImport(object instance, GetProcAddressDelegate proc_address_get_func, object proc_address_get_func_param) {
			throw new NotImplementedException();
		}		
		
		public INativeWindow CreateWindow(INativeWindow parent, int x, int y, int width, int height) {
			throw new NotImplementedException();
		}
				
		public IDisplayDevice GetDisplayDevice(string id) {
			throw new NotImplementedException();
		}
		
		public void ResetDisplayMode() {
			throw new NotImplementedException();
		}
		
		public IApplication GetApplication() {
			return UnixApplication.GetInstance();
		}
		
		public Size2 AdjustWindowSize(int clientAreaWidth, int clientAreaHeight) {
			throw new NotImplementedException();
		}
	}
}
