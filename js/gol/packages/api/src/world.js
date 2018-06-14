import math, { matrix } from 'mathjs'
const adjMatrix = [
	[-1, -1], [-1, 0], [-1, 1],
	[ 0, -1],          [ 0, 1],
	[ 1, -1], [ 1, 0], [ 1, 1],
];

export default class World {
	constructor(rows = 10, cols = 10) {
		this.matrix = matrix('sparse')
		this.matrix.resize([rows, cols])
		this.age = 0
	}

	size() {
		const [rows, cols] = this.matrix.size()
		return {rows, cols}
	}

	isAlive(i, j) {
		return this.matrix.get([i, j]) != 0
	}

	setAlive(i, j, alive) {
		return this.matrix.set([i, j], alive)
	}

	setAliveNexGen(i, j, alive) {
		this.nextGen[i] = this.nextGen[i] || {}
		this.nextGen[i][j] = alive
	}

	serialize() {
		return this.matrix.toJSON()
	}

	print() {
		return this.matrix.toArray()
	}

	addPattern(pattern, topLeft = [0, 0]) {
		const patternRows = pattern.length
		const patternCols = pattern[0].length
		let position = [
			Array(patternRows).fill(topLeft[0]),
			Array(patternCols).fill(topLeft[1])
		];
		this.matrix.subset(
			math.index(
				position[0], 
				position[1]
			),
			pattern
		)
		this.age += 1
	}

	countAliveAdj(i, j) {
		const {rows, cols} = this.size();
		return adjMatrix.filter(a => {
			const ii = i+a[0]
			const jj = j+a[1]
			if(ii < 0 || jj < 0 || ii >= rows || jj >= cols)
				return false
			return this.isAlive(ii, jj)
		}).length
	}

	completeNextGeneration() {
		Object.keys(this.nextGen).forEach(i => {
			Object.keys(this.nextGen[i]).forEach(j => {
				this.setAlive(parseInt(i), parseInt(j), this.nextGen[i][j])
			})
		})
		this.age += 1
		this.age %= 10000
	}

	nextGeneration() {
		const {rows, cols} = this.size();
		this.nextGen = {}
		let aliveAdj = 0;

		for(let i=0; i<rows; i++) {
			for(let j=0; j<cols; j++) {
				aliveAdj = this.countAliveAdj(i, j)
				if(this.isAlive(i, j) && (aliveAdj <= 1 || aliveAdj >= 4)) {
					this.setAliveNexGen(i, j, 0)
				}
				else if(!this.isAlive(i,j) && aliveAdj === 3){
					this.setAliveNexGen(i, j, 1)
				}
			}
		}
		this.completeNextGeneration()
	}
}