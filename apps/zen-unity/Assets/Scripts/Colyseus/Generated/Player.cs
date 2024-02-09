// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.26
// 

using Colyseus.Schema;
using Action = System.Action;

namespace Zen.Colyseus {
	public partial class Player : Schema {
		[Type(0, "string")]
		public string name = default(string);

		[Type(1, "ref", typeof(Vec3))]
		public Vec3 position = new Vec3();

		[Type(2, "ref", typeof(Vec4))]
		public Vec4 quaternion = new Vec4();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<string> __nameChange;
		public Action OnNameChange(PropertyChangeHandler<string> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.name));
			__nameChange += __handler;
			if (__immediate && this.name != default(string)) { __handler(this.name, default(string)); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(name));
				__nameChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Vec3> __positionChange;
		public Action OnPositionChange(PropertyChangeHandler<Vec3> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.position));
			__positionChange += __handler;
			if (__immediate && this.position != null) { __handler(this.position, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(position));
				__positionChange -= __handler;
			};
		}

		protected event PropertyChangeHandler<Vec4> __quaternionChange;
		public Action OnQuaternionChange(PropertyChangeHandler<Vec4> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.quaternion));
			__quaternionChange += __handler;
			if (__immediate && this.quaternion != null) { __handler(this.quaternion, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(quaternion));
				__quaternionChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(name): __nameChange?.Invoke((string) change.Value, (string) change.PreviousValue); break;
				case nameof(position): __positionChange?.Invoke((Vec3) change.Value, (Vec3) change.PreviousValue); break;
				case nameof(quaternion): __quaternionChange?.Invoke((Vec4) change.Value, (Vec4) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
