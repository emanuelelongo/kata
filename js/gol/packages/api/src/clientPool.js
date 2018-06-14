import {
	NEXT_GEN_MSG,
	RESYNC_MSG,
	DIRT_MSG,
	ADD_PATTERN_MSG
} from './messageTypes'
export default class ClientPool {

	constructor(world) {
		this.world = world
		this.clients = []
	}

	register(client) {
		this.clients.push(client)
		client.on(DIRT_MSG, () => {
			client.emit(RESYNC_MSG, {
				matrix: this.world.serialize(), 
				nextAge: this.world.age
			})
		})
		client.on(ADD_PATTERN_MSG, (pattern) => {
			if(!this.validate(pattern)) {
				return
			}
			this.world.addPattern(pattern, [0,0])
			client.emit(RESYNC_MSG, {
				matrix: this.world.serialize(), 
				nextAge: this.world.age
			})
		})
	}

	validate(pattern) {
		return true
	}

	update() {
		this.clients.forEach(c => {
			c.emit(NEXT_GEN_MSG, {
				updates: this.world.nextGen,
				nextAge: this.world.age
			})
		})
	}
}