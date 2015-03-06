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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IGE.Platform.Unix {
	/// <summary>
	/// </summary>
	public sealed class UnixApplication : IApplication {
		private static UnixApplication Instance;

		public event IdleEventHandler PreIdleEvent;
		public event IdleEventHandler IdleEvent;
		public event IdleEventHandler PostIdleEvent;
		
		public event ActivateAppEventHandler ActivateAppEvent;
		public event ActivateAppEventHandler DeactivateAppEvent;
		
		private bool m_KeepAliveWithoutWindows = false;
		private bool m_Exits = false;
		private bool m_Active = false;
		private static INativeWindow m_MainWindow = null;
		
		// private Dictionary<int, UnixNativeWindow> Windows = new Dictionary<int, Win32NativeWindow>();
		
		public bool KeepAliveWithoutWindows { get { return m_KeepAliveWithoutWindows; } set { m_KeepAliveWithoutWindows = value; } }
		public bool Exits { get { return m_Exits; } }
		public bool Active { get { return m_Active; } }
		public INativeWindow MainWindow { get { return m_MainWindow; } }
		
		static UnixApplication() {
			Instance = new UnixApplication();
		}
		
		private UnixApplication() {
		}

		public static UnixApplication GetInstance() {
			return Instance;
		}
		
		public bool DoLoop() {
			throw new Exception("Method not implemented");
			// return true;
		}
		
		public void Run() {
			throw new Exception("Method not implemented");
			/*
			while( !m_Exits ) {
				if( !DoLoop() ) {
					if( !m_KeepAliveWithoutWindows && Windows.Count == 0 )
						Application.Exit();
					if( PreIdleEvent != null )
						PreIdleEvent();
					if( IdleEvent != null )
						IdleEvent();
					if( PostIdleEvent != null )
						PostIdleEvent();
				}
			}*/
		}
		
		public void Exit(int exitCode) {
			throw new Exception("Method not implemented");
		}
		
		private void OnActivate(bool active) {
			m_Active = active;
			if( m_Active ) {
				if( ActivateAppEvent != null )
					ActivateAppEvent();
			}
			else {
				if( DeactivateAppEvent != null )
					DeactivateAppEvent();
			}
		}
				
		public bool AskWindowsIfCanQuit() {
			return true;
		}
	}
}
