import React from 'react'
import _ from 'lodash'
import { connect } from '../store'
import Grid from '../components/grid'
import Cell from '../components/cell'
import { initSocket, switchCell, addPattern } from '../actions'

class GameOfLife extends React.Component{
	componentDidMount () {
    	this.props.initSocket()
  	}

	render() {
		return (
			<div>
				<Grid>
					{
						_.map(this.props.patternEditor, ((r, i) => {
							return [
								_.map(r, (c, j) => <Cell alive={c > 0} cellClick={() => this.props.switchCell(i, j)} />), 
								<br />
							]
						}))
					}
				</Grid>	
				<button onClick={() => this.props.addPattern()}>Add</button>
				<Grid>
					{
						_.map(this.props.world, ((r, i) => {
							return [
								_.map(r, (c, j) => <Cell alive={c > 0} />), 
								<br />
							]
						}))
					}
				</Grid>
			</div>
		)
	}
}

function mapStateToProps(state) {
	return {
		world: state.world,
		patternEditor: state.patternEditor
	}
}

export default connect(mapStateToProps, {initSocket, switchCell, addPattern})(GameOfLife)