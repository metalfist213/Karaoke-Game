using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTest
{
	public class Entry
	{
		public static string ip = "192.168.0.102";
		public static string Connect(String server, String message) {
			string returnString ="";
			try {
				// Create a TcpClient.
				// Note, for this client to work you need to have a TcpServer 
				// connected to the same address as specified by the server, port
				// combination.
				Int32 port = 7270;
				TcpClient client = new TcpClient(server, port);


				using (NetworkStream str = client.GetStream()) {
					using (BinaryWriter writer = new BinaryWriter(str)) {
						writer.Write(message);

						using (BinaryReader reader = new BinaryReader(str)) {
							returnString = reader.ReadString();
							Console.WriteLine(returnString);

						}
					}
				}
			} catch (ArgumentNullException e) {
				Console.WriteLine("ArgumentNullException: {0}", e);
			} catch (SocketException e) {
				Console.WriteLine("SocketException: {0}", e);
			}
			return returnString;
		}

		public static void Main(string[] args) {
			Controller c = new Controller();
			Application.Run(c);
			//Connect("192.168.0.102", "set_color,1,0.5,1;set_camera,sceneFurther,0,0");
		}
	}
}
