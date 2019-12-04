using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
	class IdleEvent : KaraokeEventCollection
	{
		public IdleEvent(GameObject buzzword, GameObject camera, GameObject audience) : base(buzzword, camera, audience) {
		}

		public override void BeforeStart() {
			requiresContinue = true;
		}
	}
}
