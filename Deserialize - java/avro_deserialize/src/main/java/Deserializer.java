import org.apache.avro.Schema;
import org.apache.avro.file.DataFileReader;
import org.apache.avro.file.FileReader;
import org.apache.avro.io.BinaryDecoder;
import org.apache.avro.io.DecoderFactory;
import org.apache.avro.specific.SpecificDatumReader;
import org.apache.avro.specific.SpecificRecordBase;
import org.apache.tomcat.util.codec.binary.Base64;

import java.io.File;

public class Deserializer<T extends SpecificRecordBase> {
	protected final Class<T> typeParameterClass;

	public Deserializer(Class<T> typeParameterClass) {
		this.typeParameterClass = typeParameterClass;
	}

	public T deserializeString(String str) throws Exception {
		byte[] decoded = Base64.decodeBase64(str);

		SpecificDatumReader<T> reader = new SpecificDatumReader<>(typeParameterClass);
		BinaryDecoder decoder = DecoderFactory.get().binaryDecoder(decoded, null);

		return reader.read(null, decoder);
	}

	public T deserializeString(String str, Schema writerSchema, Schema readerSchema) throws Exception {
		byte[] decoded = Base64.decodeBase64(str);

		SpecificDatumReader<T> reader = new SpecificDatumReader<>(writerSchema, readerSchema);
		BinaryDecoder decoder = DecoderFactory.get().binaryDecoder(decoded, null);

		return reader.read(null, decoder);
	}

	public T deserializeFile(String filename) throws Exception {
		SpecificDatumReader<T> datumReader = new SpecificDatumReader<>();

		File inFile = new File(filename);

		FileReader<T> reader = DataFileReader.openReader(inFile, datumReader);
		T res = reader.next();
		reader.close();

		return res;
	}

	public T deserializeFile(String filename, Schema writerSchema, Schema readerSchema) throws Exception {
		SpecificDatumReader<T> datumReader = new SpecificDatumReader<>(writerSchema, readerSchema);

		File inFile = new File(filename);

		FileReader<T> reader = DataFileReader.openReader(inFile, datumReader);
		T res = reader.next();
		reader.close();

		return res;
	}
}