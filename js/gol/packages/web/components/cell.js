export default (props) => {
	const style = {
		backgroundColor: props.alive? "cyan" : "#ddd",
		border: "1px solid black",
		width: "20px",
		height: "20px",
		margin: "1px",
		display: "inline-block"
	}

	return (
		<div onClick={() => props.cellClick()} style={style}>&nbsp;</div>
	)
}
