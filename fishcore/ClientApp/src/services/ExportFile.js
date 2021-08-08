import React, { Component } from 'react';

export class ExportFile extends Component {

    constructor(props) {
        super(props);
        this.state = { test: '', loading: true };
    }

    componentDidMount() {
    }

    render() {
        return (
            <div>
                <button onClick={this.exportFile}> Click me </button>
            </div>
        );
    }

    async exportFile() {
        const response = await fetch('file');
        console.log(response);
        const data = await response.json();
        console.log(data);
        this.setState({ test: data, loading: false });
    }
}
