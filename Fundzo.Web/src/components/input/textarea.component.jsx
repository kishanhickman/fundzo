import { Component } from 'react';

class Textarea extends Component {
        render() {
                return (
                        <div>
                                <textarea rows={this.props.rows} type={this.props.type} name={this.props.name} placeholder={this.props.placeholder} onChange={this.props.onChange} value={this.props.value} defaultValue={this.props.defaultValue}
                                className='rounded-lg mt-1 mb-4 block w-full px-4 py-3 border border-base-300 bg-base-200 placeholder-neutral
                                focus:outline-none focus:ring-0 focus:border-primary
                                invalid:border-red
                                focus:invalid:border-red'
                                ></textarea>
                                <span className="font-bold text-error mb-4">{ this.props.errorMessage }</span>
                        </div>
                )
        }
}

export default Textarea;