import World from '../world'
let sut

describe('zeros matrix', () => {
	beforeEach(() => {
		sut = new World(10, 10)
	})

	test('should create a new world with specified size', () => {
		expect(typeof sut).toBe('object')
		expect(sut.size()).toEqual({rows:10, cols:10})
	})

	test('should convert the World to a json', () => {
		expect(sut.serialize()).toEqual({
			"datatype": undefined,
			"index": [],
			"mathjs": "SparseMatrix",
			"ptr": [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			"size": [10, 10],
			"values": []
		})
	})

	test('should output an array representation of the word', () => {
		expect(sut.print()).toEqual([
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0]])
	})
})

describe('matrix with a pattern added', () => {
	beforeEach(() => {
		sut = new World(10, 10)
		const pattern = [
			[0,0,0,0],
			[0,0,1,0],
			[0,0,0,1],
			[0,1,1,1],
		]
		const position = [1, 2]
		sut.addPattern(pattern, position)
	})

	test('should print an added pattern', () => {
	
		expect(sut.print()).toEqual([
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
			[0, 0, 0, 1, 1, 1, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
		])
	})

	test('should say that a cell is not alive', () => {
		expect(sut.isAlive(2, 3)).toBe(false)
	})

	test('should say that a cell is alive', () => {
		expect(sut.isAlive(2, 4)).toBe(true)
	})

	test('should count adjacent alive cells', () => {
		expect(sut.countAliveAdj(2, 3)).toEqual(1)
		expect(sut.countAliveAdj(3, 4)).toEqual(5)
		expect(sut.countAliveAdj(5, 5)).toEqual(2)
	})

	test('should compute next generation', () => {
		sut.nextGeneration();
		expect(sut.nextGen).toEqual({
			"2": {
				"4": 0
			}, 
			"3": {
				"3": 1
			}, 
			"4": {
				"3": 0
			}, 
			"5": {
				"4": 1
			}
		})
		expect(sut.print()).toEqual([
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 1, 0, 1, 0, 0, 0, 0],
			[0, 0, 0, 0, 1, 1, 0, 0, 0, 0],
			[0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
			[0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
		])
	})
})