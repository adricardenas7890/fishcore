import React, { Component } from 'react';

export class AboutData extends Component {
    static displayName = AboutData.name;

    constructor(props) {
        super(props);
        this.state = { test: '', loading: true };
    }

    componentDidMount() {
        this.populateAboutData();
    }

    static renderAbout(test) {
        return (
            <div>
                <p>{ test }</p>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AboutData.renderAbout(this.state.test);

        return (
            <div>
                <h1 id="tabelLabel" >About</h1>                
                {contents}
            </div>
        );
    }

    async populateAboutData() {
        const response = await fetch('about');
        console.log(response);
        const data = await response.json();
        console.log(data);
        this.setState({ test: data, loading: false });
    }
}
