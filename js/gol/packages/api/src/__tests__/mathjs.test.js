import math, { matrix } from 'mathjs'
let sut

beforeEach(() => {
	sut = matrix('sparse');
	sut.set([2, 4], "two four")
	sut.set([6, 10], "six ten")
	sut.set([4, 11], "four eleven")
	sut.set([2, 20], "two twenty")
});

test('should create a sparse matrix', () => {
	expect(sut.storage()).toBe('sparse')
})

test('should give back an assigned value', () => {
	expect(sut.get([2, 4])).toEqual('two four')
	expect(sut.get([4, 11])).toEqual('four eleven')
})

test('should get current size of the matrix', () => {
	expect(sut.size()).toEqual([7, 21])
})

test('should convert to an array', () => {
	expect(sut.toArray()).toEqual([
		[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
		[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
		[0, 0, 0, 0, "two four", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "two twenty"], 
		[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
		[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "four eleven", 0, 0, 0, 0, 0, 0, 0, 0, 0], 
		[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], 
		[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "six ten", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
	])
})

test('should return serializable version of the matrix', () => {
	expect(sut.toJSON()).toEqual({
	 	"datatype": undefined, 
	 	"index": [2, 6, 4, 2], 
	 	"mathjs": "SparseMatrix", 
	 	"ptr": [0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4], 
	 	"size": [7, 21], 
	 	"values": ["two four", "six ten", "four eleven", "two twenty"]})
})

test('should return 0 for not asssigned position', () => {
	expect(sut.get([3, 9])).toBe(0)
})

test('should throw error trying to read outside the boundary', () => {
	expect(() => { sut.get([2, 21])}).toThrow()
})

test('should resize the boundary of the matrix', () => {
	sut.resize([6, 22])
	expect(sut.get([2, 21])).toBe(0)
})

test('should restore a matrix from a json', () => {
	let restored = math.type.SparseMatrix.fromJSON({
	 	"datatype": undefined, 
	 	"index": [2, 6, 4, 2], 
	 	"mathjs": "SparseMatrix", 
	 	"ptr": [0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4], 
	 	"size": [7, 21], 
	 	"values": ["two four", "six ten", "four eleven", "two twenty"]})

	expect(restored.storage()).toBe('sparse')
	expect(sut.get([2, 4])).toEqual('two four')
	expect(sut.get([4, 11])).toEqual('four eleven')
})

test('should return a subset of a matrix', () => {
	expect(sut.subset(math.index(2, 4))).toBe('two four')
	expect(sut.subset(math.index([1, 2], [4, 5])).toArray()).toEqual([
		[0, 0],
		['two four', 0]
	])
})

test('should replace a subset of a matrix', () => {
	sut = matrix('sparse');
	sut.resize([5, 5])
	const pattern = [
		[1,2,3,4],
		[5,6,7,8]
	]
	expect(sut.subset(math.index([1,2], [1,2,3,4]), pattern).toArray()).toEqual([ 
		[ 0, 0, 0, 0, 0 ],
        [ 0, 1, 2, 3, 4 ],
        [ 0, 5, 6, 7, 8 ],
        [ 0, 0, 0, 0, 0 ],
        [ 0, 0, 0, 0, 0 ] 
    ])
})
