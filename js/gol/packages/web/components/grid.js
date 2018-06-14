export default (props) => {
	const style = {
		"textAlign": "center",
		"whiteSpace": "nowrap"
	}

	return (
		<div style={style}>
			{props.children}
		</div>
	)
}