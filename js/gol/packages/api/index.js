import io from 'socket.io'
import World from './src/world'
import ClientPool from './src/clientPool'

const GENERATIONS_PER_SECOND = 0.4

const world = new World(100, 100)
const socket = io()
const clients = new ClientPool(world)

setInterval(() => {
	console.time('nextGeneration')
	world.nextGeneration()
	console.timeEnd('nextGeneration')
	clients.update()
}, 1000 / GENERATIONS_PER_SECOND)

socket.on('connection', (client) => {
	clients.register(client);
});

socket.listen(3001)
